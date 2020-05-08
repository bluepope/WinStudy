using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Test
{
    class ArraySliceTest
    {
        public void Run()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int takeCnt = 3;
            for (var i = 0; i < arr.Length; i += takeCnt)
            {
                Console.WriteLine(string.Join(',', arr.Skip(i).Take(takeCnt).ToArray()));
            }
        }
    }
}
