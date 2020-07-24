using ConsoleApp1.Test;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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

            //new HMacTest().Run();
            //new SystemInfoTest().Run();

            //new PropertyTest().Run();

            //단순 정규식으로 문자숫자가 들어왔을때 첫번째 숫자 기준으로 나누기
            string str = "TRaADF%!123,123,123".Trim();
            int index = Regex.Match(str, "[0-9]").Index;

            string text = "";
            decimal amt = 0;

            if (index > 0)
                text = str.Substring(0, index);

            amt = Convert.ToDecimal(str.Substring(index).Replace(",", ""));
            Console.WriteLine($"{text} - {amt}");

            Console.ReadKey();

        }
    }
}
