using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using WinForm.Attributes;

namespace WinForm.Models
{
    class MUser : ModelBase
    {
        [DependsOnProperties("UNIQUE_SEQ")]
        public bool CanEdit
        {
            get => UNIQUE_SEQ <= 2;
        }

        public bool isEdit { get => GetValue<bool>(); set => SetValue(value); }

        public string USER_ID { get => GetValue<string>(); set => SetValue(value); }
        public string NAME { get => GetValue<string>(); set => SetValue(value); }
        public int UNIQUE_SEQ { get => GetValue<int>(); set => SetValue(value); }
        public DateTime REG_DATE { get => GetValue<DateTime>(); set => SetValue(value); }

        public bool USE_LOGIN { get => GetValue<bool>(); set => SetValue(value); }
    }
}
