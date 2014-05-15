using System;
using System.Diagnostics;

namespace CommandPromptUsingCSharp
{
    class Program
    {
        public void OpenWithArguments()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo("CMD.exe");

            Process p = new Process();

            startInfo.RedirectStandardInput = true;

            startInfo.UseShellExecute = false;

            startInfo.RedirectStandardOutput = true;

            startInfo.RedirectStandardError = true;

            p = Process.Start(startInfo);

            p.StandardInput.WriteLine(@"Echo on");

            p.StandardInput.WriteLine(@"dir " + @"C:");

            p.StandardInput.WriteLine(@"chdir " + @"C:\WINDOWS ");

            p.StandardInput.WriteLine(@"xcopy E:\Sample\poi.js E:\Test\ /y");

            p.StandardInput.WriteLine(@"EXIT");

            string output = p.StandardOutput.ReadToEnd();

            string error = p.StandardError.ReadToEnd();

            p.WaitForExit();

            Console.Write(output);

            p.Close();

            Console.Read();

        }

        public void RunBATFile()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\test.bat";
            proc.StartInfo.RedirectStandardError = false;
            proc.StartInfo.RedirectStandardOutput = false;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.Arguments = "C:\\source.txt C:\\Test\\";
            proc.Start();
            proc.WaitForExit();
        }

        static void Main(string[] args)
        {
            Program myProcess = new Program();

            //myProcess.OpenWithArguments();
            myProcess.RunBATFile();
        }
    }
}
