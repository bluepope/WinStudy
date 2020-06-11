using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfCore
{
    public abstract class BaseModel : INotifyPropertyChanged
    {
        public string[] _propertyNameArray;
        public BaseModel()
        {
            _propertyNameArray = this.GetType().GetProperties().Select(p => p.Name).ToArray();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RefreshProperties()
        {
            foreach(string propertyName in _propertyNameArray)
            {
                OnPropertyChanged(propertyName);
            }
        }
    }
}
