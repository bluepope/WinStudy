using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using WpfMvvm.CustomLibrary;
using WpfMvvm.Models;

namespace WpfMvvm.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    class VMTest1
    {
        public string Text1 { get; set; }

        public int Num1 { get; set; } = 20;
        public int Num2 { get; set; } = 10;

        public bool Check1 { get; set; }
        public bool Check2 { get; set; }

        public string CheckYN { get; set; } = "Y";

        public string List1SelectedValue { get; set; }

        public DateTime DateTime1 { get; set; } = DateTime.Now;
        public string DateText1 { get; set; } = DateTime.Now.ToString("yyyyMMdd");

        public List<KeyValuePair<string, string>> List1 { get; set; } = new List<KeyValuePair<string, string>>();


        //이것저것 테스트
        //public CustomList<MUser> UserList { get; set; } = new List<MUser>();
        //public IList<MUser> UserList { get; set; } = new CustomList<MUser>();
        public CustomList<MUser> UserList { get; set; } = new CustomList<MUser>();

        public DelegateCommand Button1Command { get; set; } = new DelegateCommand();
        public DelegateCommandAsync Button2Command { get; set; } = new DelegateCommandAsync();

        public DelegateCommandAsync UserListAddCommand { get; set; } = new DelegateCommandAsync();
        public DelegateCommandAsync<MUser> UserListDeleteCommand { get; set; } = new DelegateCommandAsync<MUser>();

        public CustomList<MAdmin> AdminList { get; set; }
        public VMTest1()
        {
            var list = new CustomList<MAdmin>();
            list.Add(new MAdmin() { ADMIN_SEQ = 1, ADMIN_NAME = "관리자1" });
            list.Add(new MAdmin() { ADMIN_SEQ = 2, ADMIN_NAME = "관리자2" });
            list.Add(new MAdmin() { ADMIN_SEQ = 3, ADMIN_NAME = "관리자3" });
            list.Add(new MAdmin() { ADMIN_SEQ = 4, ADMIN_NAME = "관리자4" });

            AdminList = list;

            Button1Command.ExecuteTargets += Button1Command_ExecuteTargets;
            Button2Command.ExecuteTargets += Button2Command_ExecuteTargets;

            UserListAddCommand.ExecuteTargets += () => {
                //non ThreadSafe 로 오류 발생
                return Task.Run(() => {
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                });

                //UI 쓰레드를 통해 추가
                return Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                    UserList.Add(new MUser() { isNew = true, isEdit = true });
                }).Task;
            };

            UserListDeleteCommand.ExecuteTargets += (item) => {

                //원래대로라면 UI ThreadSafe 오류 발생함
                return Task.Run(() =>
                {
                    if (item == null)
                        return;

                    if (item.isNew)
                        UserList.Remove(item);
                    else
                        item.isDelete = true;

                    //UserList.OnNotifyCollectionChanged();
                });
            };
            /*
            return Task.Run(async () =>
            {
                if (item == null)
                    return;

                if (item.isNew)
                {
                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        UserList.Remove(item);
                    });
                }
                else
                    item.isDelete = true;
            });
        };
        */

            List1.Add(new KeyValuePair<string, string>("aaa", "111"));
            List1.Add(new KeyValuePair<string, string>("bbb", "222"));
            List1.Add(new KeyValuePair<string, string>("ccc", "333"));
            List1.Add(new KeyValuePair<string, string>("ddd", "444"));

            List1SelectedValue = "222";

            UserList.Add(new MUser() { USER_ID = "a1", UNIQUE_SEQ = 1, REG_DATE = DateTime.Now.AddDays(-1), ADMIN_SEQ = 1 });
            UserList.Add(new MUser() { USER_ID = "b2", NAME = "고길동", UNIQUE_SEQ = 2, REG_DATE = DateTime.Now.AddDays(-2) });
            UserList.Add(new MUser() { USER_ID = "c3", NAME = "홍길홍", UNIQUE_SEQ = 3, REG_DATE = DateTime.Now.AddDays(-3) });
            UserList.Add(new MUser() { USER_ID = "d4", NAME = "길길동", UNIQUE_SEQ = 4, REG_DATE = DateTime.Now.AddDays(-4) });
            UserList.Add(new MUser() { USER_ID = "e5", NAME = "동길동", UNIQUE_SEQ = 5, REG_DATE = DateTime.Now.AddDays(-5) });

            foreach (var item in UserList)
            {
                item.Initialize();
            }
        }

        private void Button1Command_ExecuteTargets()
        {
            Text1 = new Random().Next().ToString();
            Num1 = new Random().Next(100);
            Num2 = new Random(Num1).Next(100);
        }

        private Task Button2Command_ExecuteTargets()
        {
            return Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Num1 = i;
                    Thread.Sleep(10);
                }
            });
        }
    }
}
