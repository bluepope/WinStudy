using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Test
{
    class HiResTimer
    {
        public void Run()
        {
            Task.Run(() => {
                var stopWatch = Stopwatch.StartNew();
                long ms = stopWatch.ElapsedMilliseconds;
                
                while (true)
                {
                    if (stopWatch.ElapsedMilliseconds - ms >= 10)
                    {
                        Console.WriteLine(stopWatch.ElapsedMilliseconds - ms);
                        ms = stopWatch.ElapsedMilliseconds;

                        Thread.Sleep(1);
                    }
                }
            });
        }
    }
}
