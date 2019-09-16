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

            Task.Run(async () =>
            {
                //람다 변수캡쳐 문제로 로컬 변수로 만들어줌
                //https://www.sysnet.pe.kr/2/0/10817
                var cts = _lastCts;
                
                //100ms 대기
                await Task.Delay(100);

                //새로운 요청이 발생했다면 이 실행은 취소됩니다
                if (cts.IsCancellationRequested)
                    return;

                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                });
            }, _lastCts.Token);
        }
    }
}
