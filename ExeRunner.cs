using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CoffeeEditor
{
    /// <summary>
    ///     Class for running exe in seprate proccess
    /// </summary>
    public static class ExeRunner
    {
        public static string Execute(string fullExePath, string exeParams)
        {
            var output = string.Empty;
            var exeProcessStartInfo = new ProcessStartInfo(fullExePath, exeParams)
                                          {
                                              WorkingDirectory =
                                                  Path.GetDirectoryName(
                                                      fullExePath), 
                                              CreateNoWindow = true, 
                                              UseShellExecute = false, 
                                              ErrorDialog = false, 
                                              RedirectStandardError = true, 
                                              RedirectStandardOutput = true
                                          };

            var exeProcess = new Process();
            exeProcess.EnableRaisingEvents = true;
            exeProcess.StartInfo = exeProcessStartInfo;
            exeProcess.Start();

            StreamReader stdReader = exeProcess.StandardOutput;
            output = stdReader.ReadToEnd();

            StreamReader errReader = exeProcess.StandardError;
            string errOut = errReader.ReadToEnd();
            exeProcess.WaitForExit();

            var errors = errOut != null && errOut.Length > 0 ? errOut : string.Empty;

            if (exeProcess.HasExited)
            {
                exeProcess.Close();
            }
            else
            {
                exeProcess.Kill();
            }

            exeProcess.Dispose();

            if (!string.IsNullOrEmpty(errors))
            {
                throw new ExeExecutionException(errors, fullExePath, exeParams);
            }

            return output;
        }
    }
}