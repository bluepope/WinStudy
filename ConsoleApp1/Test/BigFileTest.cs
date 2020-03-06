using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1.Test
{
    class BigFileTest
    {
        public void Run()
        {
            using (var file = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateFromFile("D:/backup/새 폴더/20181211.GHO"))
            {
                using (var accessor = file.CreateViewAccessor())
                {
                    var bufferSize = 4096000;
                    var buffer = new byte[bufferSize];
                    long position = 0;

                    var stopwatch = new Stopwatch();

                    stopwatch.Start();

                    while (accessor.Capacity > position)
                    {
                        accessor.ReadArray(position, buffer, 0, bufferSize);

                        position += bufferSize;

                        //Console.WriteLine(BitConverter.ToString(buffer));
                    }

                    stopwatch.Stop();
                    Console.WriteLine(stopwatch.Elapsed.ToString(@"hh\:mm\:ss"));
                }
            }
        }
    }
}
