using System;
using System.Windows;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            TextCopy.Clipboard.SetText("test clipboard");
            Console.WriteLine(TextCopy.Clipboard.GetText());
        }
    }
}
