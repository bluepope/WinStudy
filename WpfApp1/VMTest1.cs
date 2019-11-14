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
    class VMTest1 : INotifyPropertyChanged
    {
        string __text1;
        public string Text1 { get => __text1; set { __text1 = value; OnPropertyChanged(); } }

        int __num1;
        public int Num1 { get => __num1; set { __num1 = value; OnPropertyChanged(); } }

        int __num2;
        public int Num2 { get => __num2; set { __num2 = value; OnPropertyChanged(); } }

        public bool Check1 { get; set; }
        public bool Check2 { get; set; }

        public string List1SelectedValue { get; set; }

        public DateTime DateTime1 { get; set; } = DateTime.Now;
        public string DateText1 { get; set; } = DateTime.Now.ToString("yyyyMMdd");

        public List<KeyValuePair<string, string>> List1 { get; set; } = new List<KeyValuePair<string, string>>();

        public DelegateCommand<object> Button1Command { get; set; } = new DelegateCommand<object>();

        public VMTest1()
        {
            Button1Command.ExecuteTargets += Button1Command_ExecuteTargets;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Button1Command_ExecuteTargets(object obj)
        {
            Text1 = new Random().Next().ToString();
            Num1 = new Random().Next(100);
            Num2 = new Random(Num1).Next(100);
        }

    }
}
