using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp1.Test
{
    public class StringJoinTestModel
    {
        public string X { get; set; }
        public string Y { get; set; }
    }

    class StringJoinTest
    {
        public void Run()
        {
            var list = new List<StringJoinTestModel>();
            list.Add(new StringJoinTestModel() { X = "A1", Y = "B1" });
            list.Add(new StringJoinTestModel() { X = "A2", Y = "B2" });
            list.Add(new StringJoinTestModel() { X = "A3", Y = "B3" });

            Console.WriteLine(string.Join(Environment.NewLine, list.Select(p => string.Join(',', p.X, p.Y)).ToArray()));
        }
    }
}
