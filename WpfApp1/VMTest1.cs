using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfApp1
{
    class VMTest1 : BaseModel
    {
        string _text1;
        public string Text1 { get => _text1; set { _text1 = value; OnPropertyChanged(); } }

        int _num1;
        public int Num1 { get => _num1; set { _num1 = value; OnPropertyChanged(); } }

        int _num2;
        public int Num2 { get => _num2; set { _num2 = value; OnPropertyChanged(); } }

        bool _check1 = false;
        public bool Check1 { get => _check1; set { _check1 = value; OnPropertyChanged(); } }

        bool _check2 = false;
        public bool Check2 { get => _check2; set { _check2 = value; OnPropertyChanged(); } }

        public string List1SelectedValue { get; set; }

        public DateTime DateTime1 { get; set; } = DateTime.Now;
        public string DateText1 { get; set; } = DateTime.Now.ToString("yyyyMMdd");

        public List<KeyValuePair<string, string>> List1 { get; set; } = new List<KeyValuePair<string, string>>();

        public DelegateCommand<object> Button1Command { get; set; } = new DelegateCommand<object>();

        public VMTest1()
        {
            Button1Command.ExecuteTargets += Button1Command_ExecuteTargets;
        }

        private void Button1Command_ExecuteTargets(object obj)
        {
            Text1 = new Random().Next().ToString();
            Num1 = new Random().Next(100);
            Num2 = new Random(Num1).Next(100);
        }

    }
}
