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

namespace WinForm
{
    public partial class Form2 : Form
    {
        int _cnt = 1;
        int _cnt2 = 1;

        System.Threading.Timer _timer1;
        System.Windows.Forms.Timer _timer2;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_timer1 != null)
                _timer1.Dispose();

            if (_timer2 != null)
                _timer2.Dispose();

            _cnt = 1;
            _cnt2 = 1;

            _timer1 = new System.Threading.Timer((state) => {
                Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    this.Invoke(new MethodInvoker(() => {
                        lblTimer.Text = (_cnt++).ToString();
                    }));
                });
            }, null, 0, 1000);

            _timer2 = new System.Windows.Forms.Timer();
            _timer2.Interval = 1000;
            _timer2.Tick += (s, evt) =>
            {
                Task.Run(() =>
                {
                    //Thread.Sleep(500);
                    this.Invoke(new MethodInvoker(() =>
                    {
                        lblTimerControl.Text = (_cnt2++).ToString();
                    }));
                });
            };
            _timer2.Start();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _timer1.Dispose();
            _timer2.Dispose();
            base.OnClosing(e);
        }
    }
}
