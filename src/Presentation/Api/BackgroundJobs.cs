using System;
using System.Threading;
using System.Threading.Tasks;
using DAL.DbContexts;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class MigrateDatabaseJob : BackgroundService
{
    private readonly ILogger<MigrateDatabaseJob> _logger;
    private readonly DHsysContextFactory _mainContextFactory;
    private readonly IdentityContext _identityContextFactory;
    private readonly IConfiguration _configuration;
    public MigrateDatabaseJob(ILogger<MigrateDatabaseJob> logger
        ,DHsysContextFactory mainContextFactory
        ,IConfiguration configuration)
    {        
        _logger = logger;
        _mainContextFactory = mainContextFactory;
        _configuration = configuration;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try{
                _logger.LogInformation("{time} -> migrating database", DateTimeOffset.Now);
                
                var databaseUrl = _configuration.GetConnectionString("DefaultConnection");
                _logger.LogInformation("Database Url -> {connStr}",databaseUrl);
                //scope.ServiceProvider.GetRequiredService
                using var ctx = _mainContextFactory.CreateContext(databaseUrl);
                await ctx.Database.MigrateAsync();
                await this.StopAsync(stoppingToken);
            }
            catch(OperationCanceledException ex){
                _logger.LogError("{time} -> database migration failed", DateTimeOffset.Now);
                _logger.LogError("{time} -> database migration exception: {ex}", DateTimeOffset.Now,ex);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
            catch(Exception ex){
                _logger.LogError("{time} -> database migration failed", DateTimeOffset.Now);
                _logger.LogError("{time} -> database migration exception: {ex}", DateTimeOffset.Now,ex);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}

public class MigrateIdentityDatabaseJob : BackgroundService
{
    private readonly ILogger<MigrateIdentityDatabaseJob> _logger;    
    private readonly IdentityContextFactory _contextFactory;
    private readonly IConfiguration _configuration;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    private int _retryCount = 0;    
    public MigrateIdentityDatabaseJob(ILogger<MigrateIdentityDatabaseJob> logger
        ,IdentityContextFactory contextFactory
        ,UserManager<AppUser> userManager
        ,RoleManager<AppRole> roleManager
        ,IConfiguration configuration)
    {        
        _logger = logger;
        _contextFactory = contextFactory;
        _configuration = configuration;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                if(_retryCount > 5){
                    _logger.LogInformation("{time} -> migrating the identity database was not possible, stopping the background job", DateTimeOffset.Now);    
                    await this.StopAsync(stoppingToken);
                }
                _logger.LogInformation("{time} -> migrating identity database", DateTimeOffset.Now);
                
                var databaseUrl = _configuration.GetConnectionString("Identity");
                //scope.ServiceProvider.GetRequiredService
                using var ctx = _contextFactory.CreateDbContext(databaseUrl);
                _logger.LogInformation("Database Url -> {connStr}",databaseUrl);                
                await ctx.Database.MigrateAsync();
                // scope.ServiceProvider.CreateAsyncScope                
                var users = await _userManager.Users.ToListAsync();
                _logger.LogInformation("Users:{@users}",users);
                                
                await _roleManager.CreateAsync(new AppRole(AppRole.Admin));
                await _roleManager.CreateAsync(new AppRole(AppRole.BasicUser));
                await AppUser.GetAdminAsync(_userManager);
                
                await this.StopAsync(stoppingToken);
            }
            catch(OperationCanceledException ex){
                _logger.LogError("{time} -> identity database migration failed -> {ex}", DateTimeOffset.Now,ex);
                await Task.Delay(TimeSpan.FromMinutes(60), stoppingToken);
                _retryCount++;
            }
            catch(Exception ex){
                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
                _logger.LogError("{time} -> identity database migration failed -> {ex}", DateTimeOffset.Now,ex);
                _retryCount++;
            }
        }
    }
}