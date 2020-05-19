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
        Thread _timerThread;
        public void Run()
        {
            _timerThread = new Thread(() => {
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

            _timerThread.Start();

            for(int i=0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"테스트{i}");
            }
        }
    }
}
