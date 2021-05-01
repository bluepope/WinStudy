using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Test
{
    public class CurrentDirectoryTest
    {
        public void Run()
        {
            Console.WriteLine($"System.IO.Directory.GetCurrentDirectory(): {System.IO.Directory.GetCurrentDirectory()}");
            Console.WriteLine($"Environment.CurrentDirectory: {Environment.CurrentDirectory}");
            Console.WriteLine($"AppDomain.CurrentDomain.BaseDirectory: {AppDomain.CurrentDomain.BaseDirectory}");

            Console.WriteLine("--- Path ---");
            Console.WriteLine($"System.IO.Directory.GetCurrentDirectory(): {System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "runtimes")}");
            Console.WriteLine($"Environment.CurrentDirectory: {System.IO.Path.Combine(Environment.CurrentDirectory, "runtimes")}");
            Console.WriteLine($"AppDomain.CurrentDomain.BaseDirectory: {System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "runtimes")}");

        }
    }
}
