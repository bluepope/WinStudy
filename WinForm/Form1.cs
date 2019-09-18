using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForm.ViewModels;

namespace WinForm
{
    public partial class Form1 : Form
    {
        VMTest1 _viewModel;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _viewModel = new VMTest1();
            _viewModel.SetRandom();

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "아이디", DataPropertyName = "USER_ID" });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "이름", DataPropertyName = "NAME" });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "고유번호", DataPropertyName = "UNIQUE_SEQ" });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "생성일자", DataPropertyName = "REG_DATE" });

            this.dataGridView1.DataSource = _viewModel.UserList;

            var bind = textBox1.DataBindings.Add("Text", _viewModel.UserList, "UNIQUE_SEQ", true, DataSourceUpdateMode.OnPropertyChanged);
            bind.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

            bind = textBox2.DataBindings.Add("Text", _viewModel, "Text1", true, DataSourceUpdateMode.OnPropertyChanged);
            bind.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

            /*
            Task.Run(() => {
                for(int i=0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    _viewModel.UserList[0].UNIQUE_SEQ = new Random().Next(100);

                    dataGridView1.Invoke(new MethodInvoker(() => {
                        bind.ReadValue();
                        dataGridView1.Refresh();
                    }));
                }
            });
            */

            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.CellValidating += DataGridView1_CellValidating;
        }

        private void BindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            (sender as BindingSource).Current?.GetType().GetProperty("isEdit")?.SetValue((sender as BindingSource).Current, true);
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = (sender as DataGridView);
            var rowData = grid.Rows[e.RowIndex].DataBoundItem;

            if (rowData != null)
            {
                if ((bool?)(rowData.GetType().GetProperty("isDelete")?.GetValue(rowData)) == true)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else if ((bool?)(rowData.GetType().GetProperty("isNew")?.GetValue(rowData)) == true)
                {
                    e.CellStyle.BackColor = Color.Cyan;
                }
                else if ((bool?)(rowData.GetType().GetProperty("isEdit")?.GetValue(rowData)) == true)
                {
                    e.CellStyle.BackColor = Color.Orange;
                }
            }
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var grid = (sender as DataGridView);
            var oldValue = grid[e.ColumnIndex, e.RowIndex].FormattedValue;
            var newValue = e.FormattedValue;

            //null 체크 문제가 있네.. 변수형식마다 비교를 해줘야하는가?
            if (newValue.GetType() == typeof(string))
            {
                if (string.IsNullOrEmpty(newValue as string) && string.IsNullOrEmpty(oldValue as string))
                {
                    return;
                }
                else if (newValue as string == oldValue as string)
                {
                    return;
                }
            }
            else if (newValue.Equals(oldValue))
            {
                return;
            }

            var rowData = grid.Rows[e.RowIndex].DataBoundItem;

            if (rowData != null)
            {
                rowData.GetType().GetProperty("isEdit")?.SetValue(rowData, true);
                grid.Refresh();
            }

            grid[e.ColumnIndex, e.RowIndex].Value = newValue;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _viewModel.UserList[0].NAME = new Random().Next(100).ToString();
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _viewModel.Text1 = new Random().Next(100).ToString();

        }
    }
}
