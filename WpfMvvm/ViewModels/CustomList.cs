using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMvvm.ViewModels
{
    class CustomList<T> : List<T>, INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public new void Add(T item)
        {
            Add(item, false);
        }

        public void Add(T item, bool isNotifyChanged)
        {
            base.Add(item);

            if (isNotifyChanged)
                OnNotifyCollectionChanged();
        }

        public void OnNotifyCollectionChanged()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            });
        }
    }
}
