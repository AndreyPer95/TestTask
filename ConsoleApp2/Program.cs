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
            var c = DateTime.Now.Millisecond;
            while (true)
            {
                foreach (var process in Process.GetProcessesByName(nameProcess))
                {
                    if ((DateTime.Now.Millisecond - process.StartTime.Millisecond) > admissibleLifeTime * 60000)
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
