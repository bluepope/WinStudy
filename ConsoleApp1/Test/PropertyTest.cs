using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApp1.Test
{
    class PropertyTest
    {
        public void Run()
        {
            var model = new PropertyTestModel();

            //기초값 표시
            Console.WriteLine(model.Col1);
            Console.WriteLine(model.Col2);
            Console.WriteLine(model.Col3);
            Console.WriteLine(model.Col4);
            Console.WriteLine(model.Col5);

            //값 입력
            model.Col1 = 1; //그냥 프로퍼티
            model.Col2 = 2; //백킹필드
            model.Col3 = 3; //ref 를 이용한 백킹필드
            model.Col4 = 4; //리플렉션을 이용한 백킹필드 접근 
            model.Col5 = 5; //리플렉션을 이용하여 백킹필드 딕셔너리로 접근

            //값 출력
            Console.WriteLine(model.Col1);
            Console.WriteLine(model.Col2);
            Console.WriteLine(model.Col3);
            Console.WriteLine(model.Col4);
            Console.WriteLine(model.Col5);

        }
    }

    abstract class PropertyBaseModel : INotifyPropertyChanged
    {
        Dictionary<string, object> _valueStorage = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected void Set<T>(ref T backingFiled, T value)
        {
            backingFiled = value;
            OnPropertyChanged();
        }

        protected T GetReflectionField<T>([CallerMemberName] string propertyName = null)
        {
            return (T)this.GetType().GetField($"_{propertyName.Substring(0, 1).ToLower()}{propertyName.Substring(1)}", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this);
        }

        protected void SetReflectionField(object value, [CallerMemberName] string propertyName = null)
        {
            this.GetType().GetField($"_{propertyName.Substring(0, 1).ToLower()}{propertyName.Substring(1)}", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, value);
        }

        protected T GetReflectionStorage<T>([CallerMemberName] string propertyName = null)
        {
            if (_valueStorage.ContainsKey(propertyName))
            {
                return (T)_valueStorage[propertyName];
            }
            else
            {
                return default(T);
            }
            
        }

        protected void SetReflectionStorage(object value, [CallerMemberName] string propertyName = null)
        {
            _valueStorage[propertyName] = value;
        }
    }

    class PropertyTestModel : PropertyBaseModel
    {
        //아무것도 없는거
        public int Col1 { get; set; }


        //일반적인 내용
        int _col2 = 0;
        public int Col2 
        {
            get => _col2;
            set
            {
                _col2 = value;
                OnPropertyChanged(); 
            }
        }

        //Set<T> 를 이용
        int _col3 = 0;
        public int Col3
        {
            get => _col3;
            set => Set<int>(ref _col3, value);
        }

        //리플렉션을 이용 --> 이러면 잘못되었을 경우 빌드시 알수없고 런타임 오류가 발생함 
        int _col4 = 0;
        public int Col4
        {
            get => GetReflectionField<int>();
            set => SetReflectionField(value);
        }


        //리플렉션 및 딕셔너리를 이용 -> 백킹필드를 딕셔너리로 대체 함
        public int Col5
        {
            get => GetReflectionStorage<int>();
            set => SetReflectionStorage(value);
        }
    }
}
