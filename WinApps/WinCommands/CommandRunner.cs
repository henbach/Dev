using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WinCommands
{
    public static class CommandRunner
    {
        public static async Task<string> RunCommandAsync(string command, string arguments)
        {
            var tcs = new TaskCompletionSource<string>(); 
            var process = new Process 
            { 
                StartInfo = new ProcessStartInfo 
                { 
                    FileName = command, 
                    Arguments = arguments, 
                    RedirectStandardOutput = true, 
                    RedirectStandardError = true, 
                    UseShellExecute = false, 
                    CreateNoWindow = true 
                }, 
                EnableRaisingEvents = true 
            }; 
            
            string output = ""; 
            process.OutputDataReceived += (s, e) => 
                { 
                    if (e.Data != null) 
                        output += e.Data + "\n"; 
                }; 
            process.ErrorDataReceived += (s, e) => 
                { 
                    if (e.Data != null) 
                        output += e.Data + "\n"; 
                }; 
            process.Exited += (s, e) => tcs.SetResult(output); 
            
            process.Start(); 
            process.BeginOutputReadLine(); 
            process.BeginErrorReadLine(); 
            
            return await tcs.Task;
        }
        public static WinCommandOutput RunCommand(string command, string arguments)
        {
            var process = new Process();
            process.StartInfo.FileName = command;
            process.StartInfo.Arguments = arguments;

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            return new WinCommandOutput(output, error);
        }
    }
}
