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
            bind.Parse += (s, evt) => dataGridView1.Refresh();

            textBox2.DataBindings.Add("Text", _viewModel, "Text1");

            //실시간 업데이트에 대한 테스트
            dataGridView1.EditingControlShowing += (s, evt) =>
            {
                evt.Control.KeyUp += (s2, evt2) =>
                {
                    var cell = (s as DataGridView).CurrentCell;
                    _viewModel.UserList[cell.RowIndex].UNIQUE_SEQ = Convert.ToInt32((s2 as DataGridViewTextBoxEditingControl).Text);
                    bind.ReadValue();
                };
            };
                
            
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
