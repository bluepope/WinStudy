﻿using System;
using System.Collections;
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
using WpfMvvm.Models;

namespace WpfMvvm.CustomLibrary
{
    public class CustomList<T> : List<T>, INotifyCollectionChanged, IDisposable
    {
        CancellationTokenSource _lastCts;

        #region 생성자
        public CustomList() { }
        public CustomList(List<T> list) => this.AddRange(list.ConvertAll(p => p)); //deep copy
        public CustomList(IEnumerable<T> enumerable) { this.AddRange(enumerable); } //deep copy
        #endregion

        #region 상속/인터페이스 구현
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public new void Add(T item)
        {
            base.Add(item);
            OnNotifyCollectionChanged();
        }

        public new void Clear()
        {
            base.Clear();
            OnNotifyCollectionChanged();
        }
        public new void Insert(int index, T item)
        {
            base.Insert(index, item);
            OnNotifyCollectionChanged();
        }
        public new bool Remove(T item)
        {
            var r = base.Remove(item);
            OnNotifyCollectionChanged();

            return r;
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            OnNotifyCollectionChanged();
        }

        public void Dispose()
        {
            _lastCts?.Cancel();
            _lastCts?.Dispose();
            _lastCts = null;

            this.Clear();
        }

        #endregion

        #region Notify이벤트 알림
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
        #endregion
    }
}
