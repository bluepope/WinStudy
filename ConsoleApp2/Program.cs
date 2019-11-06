using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            TextCopy.Clipboard.SetText("test clipboard"); //Cross Platform
            Console.WriteLine(TextCopy.Clipboard.GetText());

            Task.Run(async () =>
            {
                //비동기 대기 사용
                var s1 = await GetAsync(1);
                var s2 = "sync";

                Console.WriteLine(s1);
                Console.WriteLine(s2);
                
                //비동기 대기 사용하지 않음 -- 먼저 실행되는 순서로 
                _ = Task.Run(async () => Console.WriteLine(await GetAsync(3)));
                _ = Task.Run(async () => Console.WriteLine(await GetAsync(2)));
                _ = Task.Run(async () => Console.WriteLine(await GetAsync(1)));

                Console.WriteLine(s2);
            }).Wait();

            Console.ReadKey();
        }

        static async Task<string> GetAsync(int n)
        {
            return await Task.Run<string>(() =>
            {
                Thread.Sleep(n * 1000);
                return $"async call {n}";
            });
        }
    }
}
