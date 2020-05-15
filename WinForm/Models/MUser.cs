using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.Models
{
    [AddINotifyPropertyChangedInterface]
    class MUser
    {
        public bool CanEdit
        {
            get => UNIQUE_SEQ <= 2;
        }

        public bool isEdit { get; set; } = false;

        public string USER_ID { get; set; }
        public string NAME { get; set; }
        public int UNIQUE_SEQ { get; set; }
        public DateTime REG_DATE { get; set; }

        public bool USE_LOGIN { get; set; }
    }
}
