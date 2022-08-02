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

            foreach (var process in Process.GetProcessesByName(nameProcess))
            {
                var startTime = process.StartTime;
                var timeNow = DateTime.Now;
                var processLifeTime = timeNow.Subtract(startTime);
                if (processLifeTime > admissible)
                {
                    process.Kill();
                    break;
                }
            }
            Thread.Sleep(frequency * 60000);

        }
    }


}
