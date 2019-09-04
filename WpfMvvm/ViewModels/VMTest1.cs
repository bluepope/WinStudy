using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfMvvm.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class VMTest1
    {
        public string Text1 { get; set; }
        public int Num1 { get; set; } = 20;

        public int Num2 { get; set; } = 10;

        public DelegateCommand<string> Button1Command { get; set; }


        public VMTest1()
        {
            Button1Command = new DelegateCommand<string>();

            Button1Command.CanExecuteTargets += () =>
            {
                return true;
            };

            Button1Command.ExecuteTargets += (s) =>
            {
                //image1.Source = new BitmapImage(new Uri("/Images/18.jpg", UriKind.Relative));
                Text1 = new Random().Next().ToString();
                Num1 = new Random().Next(100);
                Num2 = new Random(Num1).Next(100);
            };
        }
    }
}
