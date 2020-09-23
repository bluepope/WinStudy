﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WinFormCore.Models
{
    public abstract class ModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged 구현
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        #region RowState 구현
        public enum RowStateEnum
        {
            None = 0,
            New = 1,
            Modified = 2,
            Deleted = 3
        }
        public RowStateEnum RowState { get => GetValue<RowStateEnum>(); set => SetValue(value); }
        #endregion

        #region Get Set 날로먹기 구현
        Dictionary<string, object> _storage = new Dictionary<string, object>();
        public T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (_storage.ContainsKey(propertyName))
            {
                return (T)_storage[propertyName];
            }
            else
            {
                return (T)default;
            }
        }

        public void SetValue(object value, [CallerMemberName] string propertyName = null)
        {
            _storage[propertyName] = value;
            RaisePropertyChanged(propertyName);
        }
        #endregion

        #region IDispose
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    _storage.Clear();
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                _storage = null;

                disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~BaseModel()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
