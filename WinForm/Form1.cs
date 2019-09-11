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

            textBox1.TextChanged += (s, evt) => {
                dataGridView1.Refresh();
            };

            var binding = textBox1.DataBindings.Add("Text", _viewModel.SelectedUser, "UNIQUE_SEQ");
            binding.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;

            textBox2.DataBindings.Add("Text", _viewModel, "Text1");

            //dataGridView1.Rows.click

            Task.Run(() => {
                for(int i=0; i < 100; i++)
                {
                    Thread.Sleep(1000);
                    _viewModel.UserList[0].UNIQUE_SEQ = new Random().Next(100);

                    this.Invoke(new Action(() => {
                        dataGridView1.Refresh();
                        //textBox1.Refresh();
                    }));
                }
            });


            // textBox1.DataBindings.Add("", _viewModel.UserList,  )
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _viewModel.UserList[0].NAME = new Random().Next(100).ToString();
            dataGridView1.Refresh();
            textBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _viewModel.Text1 = new Random().Next(100).ToString();

        }
    }
}
