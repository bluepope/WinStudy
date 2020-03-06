using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Test
{
    class BigNumberTest
    {
        public void Run()
        {
            //var x = BigInteger.Parse("10000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
            //var y = BigInteger.Parse("10000000000000000000000000000000000000000000000000200000000000000000000000000000000000000000000");
            //Console.WriteLine((x + y).ToString());

            /* 재귀로 하면 스택 터짐 */
            //Console.WriteLine(GetFactorialRecursive(10000).ToString());

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var x = GetFactorialAsync(500000).GetAwaiter().GetResult();
            //var x = GetFactorial(500000);

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fffff"));

            Console.WriteLine("파일에 쓰는중");
            stopwatch.Restart();

            using (var sw = new System.IO.StreamWriter("output.txt"))
            {
                //BigInteger의 ToString() 에서 엄청나게 시간이 걸림... 이거 해결할수 있는 방법이 있을까?
                sw.Write(x.ToString());
                sw.Flush();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed.ToString(@"hh\:mm\:ss\.fffff"));
            Console.WriteLine("끗");
        }

        /// <summary>
        /// 비동기를 이용한 팩토리얼
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public async Task<BigInteger> GetFactorialAsync(BigInteger num)
        {
            BigInteger x = 1;
            int div = 10000;

            var taskList = new List<Task<BigInteger>>();

            if (num < div)
            {
                x = GetFactorial(num);
            }
            else
            {
                int maxStep = (int)(num / div);

                Console.WriteLine($"분할 합계를 만드는 중 {div}단위");
                for (int i = 0; i <= maxStep; i++)
                {
                    int from = (i * div) + 1;
                    int to = ((i + 1) * div);

                    Console.WriteLine($"{from} - {to}");

                    if (i == maxStep)
                    {
                        taskList.Add(Task.Run(() => GetFactorial(from, num)));
                    }
                    else
                    {
                        taskList.Add(Task.Run(() => GetFactorial(from, to)));
                    }
                }

                Task.WaitAll(taskList.ToArray());
                
                int cnt = 1;
                int maxCnt = taskList.Count;

                //나눠서 합치는것도 Task 잘 쪼개면 성능 올릴수 있을거 같은데......
                Console.WriteLine("분할 합계를 합치는 중");
                foreach (var factorialResult in taskList)
                {
                    Console.WriteLine($"{cnt++} / {maxCnt}");
                    x *= await factorialResult;
                }
            }

            return x;
        }

        /// <summary>
        /// 단순 팩토리얼
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public BigInteger GetFactorial(BigInteger num)
        {
            return GetFactorial(1, num);
        }

        /// <summary>
        /// 팩토리얼 from - to
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public BigInteger GetFactorial(BigInteger from, BigInteger to)
        {
            BigInteger x = 1;

            for (BigInteger i = from; i <= to; i++)
            {
                if (i < 2)
                    x = x * 1;

                x = x * i;
            }

            return x;
        }

        /// <summary>
        /// 재귀를 이용한 팩토리얼 - 스택터짐
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public BigInteger GetFactorialRecursive(BigInteger x)
        {
            if (x < 1)
                return 1;

            return x * GetFactorialRecursive(x - 1);
        }
    }
}
