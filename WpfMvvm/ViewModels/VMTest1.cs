using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class VMTest1
    {
        public string Text1 { get; set; }
        public int Num1 { get; set; } = 20;

        public int Num2 { get; set; } = 10;
    }
}
