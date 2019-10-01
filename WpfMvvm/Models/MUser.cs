using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvm.CustomLibrary;

namespace WpfMvvm.Models
{
    [AddINotifyPropertyChangedInterface]
    class MUser : INotifyPropertyChanged
    {
        bool _isInitialize = false;

        public bool CanEdit
        {
            get => UNIQUE_SEQ <= 2;
        }

        public bool isNew { get; set; } = false;
        public bool isEdit { get; set; } = false;
        public bool isDelete { get; set; } = false;

        public string USER_ID { get; set; }
        public string NAME { get; set; }
        public int UNIQUE_SEQ  { get; set; }
        public DateTime REG_DATE { get; set; }

        public int ADMIN_SEQ { get; set; }

        CustomList<MAdmin> _list = new CustomList<MAdmin>();
        public CustomList<MAdmin> UserAdminList
        {
            get
            {
                return new CustomList<MAdmin>(_list.Where(p => p.ADMIN_SEQ >= UNIQUE_SEQ));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MUser()
        {
            _list.Add(new MAdmin() { ADMIN_SEQ = 1, ADMIN_NAME = "관리자1" });
            _list.Add(new MAdmin() { ADMIN_SEQ = 2, ADMIN_NAME = "관리자2" });
            _list.Add(new MAdmin() { ADMIN_SEQ = 3, ADMIN_NAME = "관리자3" });
            _list.Add(new MAdmin() { ADMIN_SEQ = 4, ADMIN_NAME = "관리자4" });

            PropertyChanged = MUser_PropertyChanged;
        }

        public void Initialize()
        {
            this.isEdit = false;
            _isInitialize = true;
        }

        private void MUser_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_isInitialize && isEdit == false)
            {
                this.isEdit = true;
            }
        }
    }
}
