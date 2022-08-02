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
        static void Main(string[] args)
        {
            var nameProcess = args[0];
            var admissibleLifeTime = int.Parse(args[1]);
            var frequency = int.Parse(args[2]);
            var admissible = new TimeSpan(0, admissibleLifeTime, 0);
            while (true)
            {

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

    
}
