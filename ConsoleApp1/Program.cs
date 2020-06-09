using ConsoleApp1.Test;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //new BigFileTest().Run();
            //new DbTest().Run();
            //new BigNumberTest().Run();
            //new JsonTest().Run();
            //new PostgreSqlBulkInsertTest().Run();

            //new ArraySliceTest().Run();
            //new HiResTimer().Run();

            //브라우저 실행하기
            /*
            Process.Start(new ProcessStartInfo
            {
                FileName = "http://www.google.com",
                UseShellExecute = true
            });
            */

            new SystemInfoTest().Run();

            Console.ReadKey();

        }
    }
}
