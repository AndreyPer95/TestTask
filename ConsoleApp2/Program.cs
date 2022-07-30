using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;



namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameProcess = args[0];
            var lifeTime = args[1];
            var frequency = args[2];
            while (true)
            {
                foreach (var process in Process.GetProcessesByName(nameProcess))
                {
                    if ((DateTime.Now - process.StartTime).TotalMilliseconds > int.Parse(lifeTime) * 60000)
                    {
                        process.Kill();
                        break;
                    }
                }
                Thread.Sleep(int.Parse(frequency) * 60000);
            }

        }
    }

    
}
