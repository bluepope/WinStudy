using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        List<MCombo> _combo = new List<MCombo>();
        VMTest1 _viewModel;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.button6.Click += async (s, evt) => await this.button6_Click(s, evt);


            _viewModel = new VMTest1();
            _viewModel.SetRandom();

            this.progressBar1.DataBindings.Add("Value", _viewModel, "Num1");

            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "아이디", DataPropertyName = "USER_ID" });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "이름", DataPropertyName = "NAME" });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "고유번호", DataPropertyName = "UNIQUE_SEQ" });
            this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "생성일자", DataPropertyName = "REG_DATE" });
            this.dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn() { Name = "로그인가능", DataPropertyName = "USE_LOGIN" });

            this.dataGridView1.DataSource = _viewModel.UserList;
            this.dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            this.dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;

            var bind = textBox1.DataBindings.Add("Text", _viewModel.UserList, "UNIQUE_SEQ", true, DataSourceUpdateMode.OnPropertyChanged);
            bind.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;

            textBox2.DataBindings.Add("Text", _viewModel, "Text1");
            textBox4.DataBindings.Add("Text", _viewModel, "Text1");

            //실시간 업데이트에 대한 테스트
            Task.Run(() => {
                for(int i=0; i < 100; i++)
                {
                    Thread.Sleep(100);
                    _viewModel.UserList[0].UNIQUE_SEQ = new Random().Next(100);
                }
            });


            _combo.Add(new MCombo() { Value = "v1", Text = "t1" });
            _combo.Add(new MCombo() { Value = "v2", Text = "t2" });
            _combo.Add(new MCombo() { Value = "v3", Text = "t3" });
            var bs = new BindingSource();
            bs.DataSource = _combo;

            this.comboBox1.DisplayMember = "Text";
            this.comboBox1.ValueMember = "Value";
            this.comboBox1.DataSource = bs;

            this.comboBox2.DisplayMember = "Text";
            this.comboBox2.ValueMember = "Value";
            this.comboBox2.DataSource = bs;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            (sender as DataGridView).CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _viewModel.UserList[0].NAME = new Random().Next(100).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _viewModel.Text1 = new Random().Next(100).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _viewModel.SetRandom();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var form = new Form2())
            {
                form.ShowDialog();
            }
        }

        string _beforeText;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var textbox = (sender as TextBox);
            var text = textbox.Text;
            int cursorPos = textbox.SelectionStart;

            ulong result = 0;

            if (string.IsNullOrEmpty(text) == false && ulong.TryParse(text, System.Globalization.NumberStyles.AllowHexSpecifier, System.Globalization.CultureInfo.CurrentCulture, out result) == false)
            {
                textbox.Text = _beforeText;
                //System.Windows.Forms.MessageBox.Show("need hex!");

                textbox.SelectionStart = cursorPos - 1;
                textbox.SelectionLength = 0;
            }
            else
            {
                _beforeText = text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _combo.Add(new MCombo() { Value = txtValue.Text, Text = txtText.Text });

            (comboBox1.DataSource as BindingSource).ResetBindings(false);
            (comboBox2.DataSource as BindingSource).ResetBindings(false);
        }

        private async Task button6_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            await Task.Delay(5000);
            (sender as Button).Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                (sender as Button).Enabled = false;
                await Task.Delay(5000);
                (sender as Button).Enabled = true;
            });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int rowIdx = new Random().Next(dataGridView1.Rows.Count - 1);

            dataGridView1.CurrentCell = dataGridView1.Rows[rowIdx].Cells[0];
        }
    }

    public class MCombo
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
