using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Test
{
    class RegexTest
    {
        public void Run()
        {
            //단순 정규식으로 문자숫자가 들어왔을때 첫번째 숫자 기준으로 나누기
            string str = "TRaADF%!123,123,123".Trim();
            int index = Regex.Match(str, "[0-9]").Index;

            string text = "";
            decimal amt = 0;

            if (index > 0)
                text = str.Substring(0, index);

            amt = Convert.ToDecimal(str.Substring(index).Replace(",", ""));
            Console.WriteLine($"{text} - {amt}");
        }
    }
}
