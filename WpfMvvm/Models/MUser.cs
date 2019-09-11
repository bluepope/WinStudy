﻿using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool isEdit { get; set; } = false;

        public string USER_ID { get; set; }
        public string NAME { get; set; }
        public int UNIQUE_SEQ  { get; set; }
        public DateTime REG_DATE { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MUser()
        {
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