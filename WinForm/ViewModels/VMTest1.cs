using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WinForm.Models;

namespace WinForm.ViewModels
{
    class VMTest1
    {
        public string Text1 { get; set; }

        public int Num1 { get; set; } = 20;
        public int Num2 { get; set; } = 10;

        public bool Check1 { get; set; }
        public bool Check2 { get; set; }

        public string List1SelectedValue { get; set; }

        public DateTime DateTime1 { get; set; } = DateTime.Now;
        public string DateText1 { get; set; } = DateTime.Now.ToString("yyyyMMdd");

        public List<KeyValuePair<string, string>> List1 { get; set; } = new List<KeyValuePair<string, string>>();

        public BindingList<MUser> UserList { get; set; }

        public VMTest1()
        {
            List1.Add(new KeyValuePair<string, string>("aaa", "111"));
            List1.Add(new KeyValuePair<string, string>("bbb", "222"));
            List1.Add(new KeyValuePair<string, string>("ccc", "333"));
            List1.Add(new KeyValuePair<string, string>("ddd", "444"));

            List1SelectedValue = "222";

            UserList = new BindingList<MUser>();
            UserList.Add(new MUser() { USER_ID = "a1", UNIQUE_SEQ = 1, REG_DATE = DateTime.Now.AddDays(-1) });
            UserList.Add(new MUser() { USER_ID = "b2", NAME = "고길동", UNIQUE_SEQ = 2, REG_DATE = DateTime.Now.AddDays(-2) });
            UserList.Add(new MUser() { USER_ID = "c3", NAME = "홍길홍", UNIQUE_SEQ = 3, REG_DATE = DateTime.Now.AddDays(-3) });
            UserList.Add(new MUser() { USER_ID = "d4", NAME = "길길동", UNIQUE_SEQ = 4, REG_DATE = DateTime.Now.AddDays(-4) });
            UserList.Add(new MUser() { USER_ID = "e5", NAME = "동길동", UNIQUE_SEQ = 5, REG_DATE = DateTime.Now.AddDays(-5) });
        }

        public void SetRandom()
        {
            Text1 = new Random().Next().ToString();
            Num1 = new Random().Next(100);
            Num2 = new Random(Num1).Next(100);
        }
    }
}
