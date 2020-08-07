using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Test
{
    class XssCheckerTest
    {
        public void Run()
        {
            string html = @"문의 드려요 <br>
<br>
<img src=""http://xx.xx"">
<script src=""http://xxx.xxx""></script><br>( 전화번호 : xx-xxx-xxx)<br>
            ";

            Console.WriteLine($"origin: {html}");
            string x = new Ganss.XSS.HtmlSanitizer().Sanitize(html);
            Console.WriteLine($"result: {x}");
        }
    }
}
