using System;
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
    public class CustomList<T> : IList<T>, INotifyCollectionChanged
    {
        List<T> _list = new List<T>();
        CancellationTokenSource _lastCts;

        #region 생성자
        public CustomList() { }
        public CustomList(List<T> list) => this._list = list.ConvertAll(p => p); //deep copy
        public CustomList(IList<T> ilist) => this._list = ilist.ToList(); //deep copy
        #endregion

        #region 인터페이스 구현
        public T this[int index] { get => _list[index]; set => _list[index] = value; }
        public int Count => _list.Count;
        public bool IsReadOnly => false;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void Add(T item)
        {
            _list.Add(item);
            OnNotifyCollectionChanged();
        }

        public void Clear()
        {
            _list.Clear();
            OnNotifyCollectionChanged();
        }
        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            OnNotifyCollectionChanged();
        }
        public bool Remove(T item)
        {
            var r = _list.Remove(item);
            OnNotifyCollectionChanged();

            return r;
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            OnNotifyCollectionChanged();
        }

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        public int IndexOf(T item) =>_list.IndexOf(item);

        IEnumerator IEnumerable.GetEnumerator() =>  _list.GetEnumerator();
        #endregion

        #region 연산자 정의
        public static implicit operator CustomList<T>(List<T> list)
        {
            return new CustomList<T>(list);
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
