﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using WinFormCore.Attributes;

namespace WinFormCore.Models
{
    public class TestModel : ModelBase
    {
        public string Col1 { get => GetValue<string>(); set => SetValue(value); }
        public string Col2 { get => GetValue<string>(); set => SetValue(value); }
        
        [DependsOnProperties("Col2")]
        public string Col2Copy => Col2;


        public static BindingList<TestModel> GetList()
        {
            var list = new BindingList<TestModel>();

            list.Add(new TestModel() { Col1 = "aaa", Col2 = "111" });
            list.Add(new TestModel() { Col1 = "bbb", Col2 = "222" });
            list.Add(new TestModel() { Col1 = "ccc", Col2 = "333" });

            return list;
        }
    }
}
