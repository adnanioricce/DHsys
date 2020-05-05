using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Desktop
{
    public class UpdateManager
    {
        private readonly IAppLogger<UpdateManager> _logger;
        public UpdateManager(IAppLogger<UpdateManager> logger)
        {
            _logger = logger;
        }
        public async Task CheckForSquirrelUpdates()
        {
            try {
                var (exitCode, output) = await RunSquirrel("--update https://example.org/updates");

                if (exitCode != 0) {
                    // TODO: Log update errors to Sentry
                    _logger.LogError($"Failed to update! {output}");
                }
            } catch (Exception ex) {
                _logger.LogError($"Failed to invoke Update.exe",ex);
            }
        }

        public Task<(int exitCode, string output)> RunSquirrel(string args)
        {
            string updateDotExe;
            try {
                updateDotExe = Path.GetFullPath("../Update.exe", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));

                if (!File.Exists(updateDotExe)) throw new Exception("update.exe doesn't exist");
            } catch (Exception ex) {
                _logger.LogStackTrace($"Update.exe not found, this is probably not a deployed app",ex);
                return Task.FromException<(int, string)>(new Exception("Not a deployed app"));
            }

            return InvokeProcessAsync(updateDotExe, args, CancellationToken.None, Path.GetDirectoryName(updateDotExe));
        }

        public bool IsAppDeployed()
        {
            var updateDotExe = Path.GetFullPath("../Update.exe", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
            return File.Exists(updateDotExe);
        }

        private static Task<(int exitCode, string output)> InvokeProcessAsync(string fileName, string arguments, CancellationToken ct, string workingDirectory = "")
        {
            var psi = new ProcessStartInfo(fileName, arguments)
            {
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                WorkingDirectory = workingDirectory
            };

            return InvokeProcessAsync(psi, ct);
        }

        private static async Task<(int exitCode, string output)> InvokeProcessAsync(ProcessStartInfo psi, CancellationToken ct)
        {
            var pi = Process.Start(psi);
            await Task.Run(() => {
                while (!ct.IsCancellationRequested) {
                    if (pi.WaitForExit(2000)) return;
                }

                if (ct.IsCancellationRequested) {
                    pi.Kill();
                    ct.ThrowIfCancellationRequested();
                }
            });

            string textResult = await pi.StandardOutput.ReadToEndAsync();
            if (String.IsNullOrWhiteSpace(textResult) || pi.ExitCode != 0) {
                textResult = (textResult ?? "") + "\n" + await pi.StandardError.ReadToEndAsync();

                if (String.IsNullOrWhiteSpace(textResult)) {
                    textResult = String.Empty;
                }
            }

            return (pi.ExitCode, textResult.Trim());
        }
    }
}