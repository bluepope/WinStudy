using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinForm1
{
    public class TestModel1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        string _col1;

        public string Col1 { get => _col1; set { _col1 = value; RaisePropertyChanged(); } }

        string _col2;
        public string Col2 { get => _col2; set { _col2 = value; RaisePropertyChanged(); } }

    }
}
