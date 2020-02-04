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
                var s1 = await GetAsync(1, "동기대기");

                Console.WriteLine(s1);

                //비동기 대기 사용하지 않음 -- 먼저 실행되는 순서로, 도중에 스레드가 종료되면 취소됨
                //_ = Task.Run(async () => Console.WriteLine(await GetAsync(3)));

                //await 호출 순서 보기
                Console.WriteLine("비동기 호출시 await 사용시작");
                var t3 = GetAsync(3, "비동기 호출");
                var t2 = GetAsync(2, "비동기 호출");
                Task<string> t1 = GetAsync(1, "비동기 호출");

                //핵심은 변수를 실제 사용하려고할때 await 를 걸고 사용한다는거
                //반환값을 Task<T> 받았기때문에 await로 해야 변수로 변환됨
                //어느 시점에 await 를 쓸지 생각을 잘해야할듯..
                //사용할때마다 await 로 할건지 아니면 다른변수에 담아서 처리할건지?
                Console.WriteLine(await t1);
                Console.WriteLine(await t2);
                Console.WriteLine(await t3);
            }).Wait();

            Console.WriteLine("끝!");
            Console.ReadKey();
        }

        static async Task<string> GetAsync(int n, string s)
        {
            return await Task.Run<string>(() =>
            {
                Thread.Sleep(n * 1000);
                return $"async call {s} - {n}";
            });
        }
    }
}
