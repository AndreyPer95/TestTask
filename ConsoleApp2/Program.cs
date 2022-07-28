using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var process in Process.GetProcessesByName(args[0]))
            {
                if ((DateTime.Now - process.StartTime).TotalMilliseconds > int.Parse(args[1])*1000)
                process.Kill();
                System.Threading.Thread.Sleep(int.Parse(args[2]) * 1000);
            }

        }
    }

    
}
