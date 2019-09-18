using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm.Models
{
    [AddINotifyPropertyChangedInterface]
    class MUser
    {
        public bool CanEdit
        {
            get => UNIQUE_SEQ <= 2;
        }

        public bool isNew { get; set; } = false;
        public bool isEdit { get; set; } = false;
        public bool isDelete { get; set; } = false;

        public string USER_ID { get; set; }
        public string NAME { get; set; }
        public int UNIQUE_SEQ { get; set; }
        public DateTime REG_DATE { get; set; }

        public MUser()
        {
        }
    }
}
