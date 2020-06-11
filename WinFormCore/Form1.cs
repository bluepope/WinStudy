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

namespace WinFormCore
{
    public partial class Form1 : Form
    {
        CancellationTokenSource _cts = null;

        public Form1()
        {
            InitializeComponent();

            progressBar1.Maximum = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_cts != null)
            {
                _cts.Cancel();
            }

            var cts = new CancellationTokenSource();

            Task.Run(async () => {
                for(int i=0; i <= 100; i += 10)
                {
                    if (cts.IsCancellationRequested)
                        return;

                    progressBar1.Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Value = i;
                    }));

                    await Task.Delay(500);
                }
            }, cts.Token);

            _cts = cts;
            
            //textBox1.Text = "test";
        }
    }
}
