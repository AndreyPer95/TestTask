using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;



namespace KillUtilite
{
    class Program
    {
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Unhandled Exception: " + Environment.NewLine + e.ExceptionObject.ToString());
        }


        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            var nameProcess = args[0];
            var admissibleLifeTime = int.Parse(args[1]);
            var frequency = int.Parse(args[2]);
            var admissible = new TimeSpan(0, admissibleLifeTime, 0);
            var processes = Process.GetProcessesByName(nameProcess);
            while (true)
            {
                if (processes.Count() == 0)
                {
                    Console.WriteLine($"Process {nameProcess} not found");
                    break;
                }

                foreach (var process in processes)
                {
                    if (process.HasExited)
                    {
                        Console.WriteLine($"Process {nameProcess} has completed before");
                        return;
                    }
                    var startTime = process.StartTime;
                    var timeNow = DateTime.Now;
                    var processLifeTime = timeNow.Subtract(startTime);
                    if (processLifeTime > admissible)
                    {
                        process.Kill();
                        Console.WriteLine($"Process {nameProcess} was successfully completed by the program.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Process {nameProcess} is running. Operating time below allowable.");
                    }
                }

                Thread.Sleep(frequency * 60000);
            }

            
        }
    }


}
