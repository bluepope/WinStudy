using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMvvm.ViewModels
{
    public class CustomList<T> : List<T>, INotifyCollectionChanged
    {
        CancellationTokenSource _lastCts;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public new void Add(T item)
        {
            base.Add(item);
            OnNotifyCollectionChanged();
        }
        public new void Remove(T item)
        {
            base.Remove(item);
            OnNotifyCollectionChanged();
        }

        public void OnNotifyCollectionChanged()
        {
            //기존 작업이 있다면 취소함
            _lastCts?.Cancel();
            _lastCts?.Dispose();

            _lastCts = new CancellationTokenSource();
            RunNotifyCollectionChanged(_lastCts);
        }

        async void RunNotifyCollectionChanged(CancellationTokenSource cts)
        {
            //100ms 대기
            await Task.Delay(100);

            if (cts.IsCancellationRequested)
                return;

            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            });
        }
    }
}
