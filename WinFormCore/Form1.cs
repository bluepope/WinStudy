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

using WinFormCore.Models;

namespace WinFormCore
{
    public partial class Form1 : Form
    {
        BindingList<TestModel> _viewModel;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            popeGrid1.AddColumn("Col1", "컬럼1", 50, WinFormCore.Controls.PopeGrid.ColType.OnlyNewEdit);
            popeGrid1.AddColumn("Col2", "컬럼2", 50, WinFormCore.Controls.PopeGrid.ColType.Edit);
            popeGrid1.AddColumn("RowState", "Row상태", 50, WinFormCore.Controls.PopeGrid.ColType.ReadOnly);

            _viewModel = TestModel.GetList();

            popeGrid1.DataSource = _viewModel;
        }

        private void popeButton1_Click(object sender, EventArgs e)
        {
            _viewModel[1] = new TestModel() { Col1 = "random", Col2 = new Random().Next(1000).ToString() };
        }

        private void popeButton2_Click(object sender, EventArgs e)
        {
            _viewModel[0].Col2 = new Random().Next(1000).ToString();
        }

        private void popeButton3_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _viewModel[0].Col2 = new Random().Next(1000).ToString();
                    await Task.Delay(500);
                }
            });
        }

        private void popeButton4_Click(object sender, EventArgs e)
        {
            popeGrid1.AddRow();
        }

        private void popeButton5_Click(object sender, EventArgs e)
        {
            popeGrid1.DeleteRow();
        }
    }
}
