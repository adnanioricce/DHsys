using System.Collections.Generic;
using IdentityServer4.Models;

namespace Api
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityServer4.Models.IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()                
            };
        public static IEnumerable<IdentityServer4.Models.ApiScope> ApiScopes =>
            new List<IdentityServer4.Models.ApiScope>{
                new ApiScope("dhsysapi","DHsys API"),
                new ApiScope("swagger","DHsys API Docs"),
                new ApiScope("admin", "api scope of admins"),
                new ApiScope("operator", "api scope of operators")
            };
        public static IEnumerable<Client> Clients => new List<Client>{
            new Client {
                ClientId = "spa",
                AllowedGrantTypes = GrantTypes.Code,
                // secret for authentication    
                RequireClientSecret = false,
                // scopes that client has access to
                AllowedScopes =          { "dhsysapi" },
                RedirectUris =           { "http://localhost:9527/#/login?redirect=dashboard" },
                PostLogoutRedirectUris = { "http://localhost:9527/#/dashboard" },
                AllowedCorsOrigins =     { "https://localhost:5001", "http://localhost:9527" },
            },
            new Client {
                ClientId = "swagger",
                AllowedGrantTypes = GrantTypes.ClientCredentials,                
                ClientSecrets = {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "swagger" },                
            },
            new Client {
                ClientId = "js-dev",
                AllowedGrantTypes = GrantTypes.Code,
                RequireClientSecret = false,
                AllowedScopes = { "dhsysapi" },
                RedirectUris = {"https://localhost:5001/callback.html"},
                PostLogoutRedirectUris = { "https://localhost:5001/index.html"},
                AllowedCorsOrigins = {"https://localhost:5001"}
            }
        };
    }
}