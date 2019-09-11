using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm.Controls
{
    public class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            this.EditMode = DataGridViewEditMode.EditOnEnter;
        }

        public void AddColumn()
        {

        }
    }

    public class Data
    {

    }
}
