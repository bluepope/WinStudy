using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace WinForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //dataGridView1.RowEnter += DataGridView1_RowEnter;

            /*
            var dt = new DataTable();
            dt.Columns.Add("Col1");
            dt.Columns.Add("Col2");

            dt.Rows.Add(new string[] { "1",  "a" });
            dt.Rows.Add(new string[] { "2", "b" });

            dataGridView1.DataSource = dt;
            */

            var model = new BindingList<TestModel1>();
            model.Add(new TestModel1() { Col1 = "1", Col2 = "a" });
            model.Add(new TestModel1() { Col1 = "2", Col2 = "b" });
         
            dataGridView1.DataSource = model;

            txtCol1.DataBindings.Add("Text", model, "Col1");
            txtCol2.DataBindings.Add("Text", model, "Col2");
        }

        private void DataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var row = (sender as DataGridView).Rows[e.RowIndex];
            //txtCol1.Text = row.Cells["col1"].Value.ToString();
            //txtCol2.Text = row.Cells["col2"].Value.ToString();

            //DataGridViewRowToPanel(row, groupBox2);


            txtCol1.DataBindings.Clear();
            txtCol2.DataBindings.Clear();

            var x = (row.DataBoundItem as TestModel1);

            var y = JsonConvert.DeserializeObject<TestModel1>(JsonConvert.SerializeObject(x));

            txtCol1.DataBindings.Add("Text", y, "Col1");
            txtCol2.DataBindings.Add("Text", y, "Col2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var y = (txtCol1.DataBindings[0].DataSource as TestModel1);

            var row = dataGridView1.SelectedCells[0].OwningRow;

            (row.DataBoundItem as TestModel1).Col1 = y.Col1;
            (row.DataBoundItem as TestModel1).Col2 = y.Col2;


        }

        void DataGridViewRowToPanel(DataGridViewRow originRow, Control panel)
        {
            var cmd = new SqlCommand();

            foreach (DataGridViewCell col in originRow.Cells)
            {
                //cmd.Parameters.AddWithValue($"@{col.OwningColumn.DataPropertyName}", col.Value);
            
                var childControls = panel.Controls.Find($"txt{col.OwningColumn.DataPropertyName}", true);

                if (childControls?.Length > 0)
                {
                    (childControls[0] as TextBox).Text = col.Value as string;
                }
            }

            //cmd.ExecuteNonQuery();
        }

        void PanelToDataGridViewRow(Control panel, DataGridViewRow targetRow)
        {
            foreach (DataGridViewCell col in targetRow.Cells)
            {
                var childControls = panel.Controls.Find($"txt{col.OwningColumn.DataPropertyName}", true);

                if (childControls?.Length > 0)
                {
                    col.Value = (childControls[0] as TextBox).Text;
                }
            }
        }
    }
}
