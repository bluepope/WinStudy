using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using WinForm.Attributes;

namespace WinForm.Models
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
        Dictionary<string, string[]> _notifyLinkStorage = new Dictionary<string, string[]>();

        public T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            object val;

            if (_storage.TryGetValue(propertyName, out val))
            {
                return (T)val;
            }
            else
            {
                return default;
            }
        }

        public void SetValue(object value, [CallerMemberName] string propertyName = null)
        {
            _storage[propertyName] = value;
            RaisePropertyChanged(propertyName);

            string[] notifyLinks;
            if (_notifyLinkStorage.TryGetValue(propertyName, out notifyLinks) == false)
            {
                var list = new List<string>();

                foreach (var property in this.GetType().GetProperties())
                {
                    var prop = property.GetCustomAttribute<DependsOnPropertiesAttribute>(false);
                    if (prop != null && prop.ParentPropertyNames != null && prop.ParentPropertyNames.Contains(propertyName))
                    {
                        list.Add(property.Name);
                    }
                }

                notifyLinks = list.ToArray();
                _notifyLinkStorage.Add(propertyName, notifyLinks);
            }

            if (notifyLinks != null && notifyLinks.Length > 0)
            {
                foreach (var name in notifyLinks)
                {
                    RaisePropertyChanged(name);
                }
            }
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
                    _notifyLinkStorage.Clear();
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                _storage = null;
                _notifyLinkStorage = null;

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
