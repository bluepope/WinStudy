using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp1.Test
{
    class HMacTest
    {
        public void Run()
        {
            var sha = new System.Security.Cryptography.HMACSHA512();
            sha.Key = System.Text.Encoding.UTF8.GetBytes("키키킥");
            var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes("쿄쿄쿅"));
            Console.WriteLine(System.Convert.ToBase64String(hash));

            sha.Key = System.Text.Encoding.UTF8.GetBytes("킥키키");
            hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes("쿄쿄쿅"));
            Console.WriteLine(System.Convert.ToBase64String(hash));
        }
    }
}
