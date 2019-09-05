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

        public bool Check1 { get; set; }
        public bool Check2 { get; set; }

        public string List1SelectedValue { get; set; }

        public DateTime DateTime1 { get; set; } = DateTime.Now;
        public string DateText1 { get; set; } = DateTime.Now.ToString("yyyyMMdd");

        public List<KeyValuePair<string, string>> List1 { get; set; } = new List<KeyValuePair<string, string>>();

        public DelegateCommand<string> Button1Command { get; set; } = new DelegateCommand<string>();


        public VMTest1()
        {
            Button1Command.CanExecuteTargets += () =>
            {
                return true;
            };

            Button1Command.ExecuteTargets += (s) =>
            {
                Text1 = new Random().Next().ToString();
                Num1 = new Random().Next(100);
                Num2 = new Random(Num1).Next(100);
            };

            List1.Add(new KeyValuePair<string, string>("aaa", "111"));
            List1.Add(new KeyValuePair<string, string>("bbb", "222"));
            List1.Add(new KeyValuePair<string, string>("ccc", "333"));
            List1.Add(new KeyValuePair<string, string>("ddd", "444"));

            List1SelectedValue = "222";
        }
    }
}
