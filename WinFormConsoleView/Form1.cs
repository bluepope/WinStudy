using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormConsoleView
{
    public partial class Form1 : Form
    {
        private StringBuilder cmdOutput = null;
        bool _isFirstRowDelete = false;
        FixedProcess cmdProcess;
        StreamWriter cmdStreamWriter;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmdOutput = new StringBuilder("");

            //Process로 하면 OutputDataReceived 이벤트 발생기준이 NewLine 이라서 마지막줄을 못가져옴
            //Stackoverflow 에서 커스텀 버전을 봄
            //https://stackoverflow.com/questions/1033648/c-sharp-redirect-console-application-output-how-to-flush-the-output
            cmdProcess = new FixedProcess();

            cmdProcess.StartInfo.FileName = "cmd";
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.OutputDataReceived += CmdProcess_OutputDataReceived;
            cmdProcess.EnableRaisingEvents = true;
            cmdProcess.Exited += CmdProcess_Exited;
            
            cmdProcess.Start();

            cmdStreamWriter = cmdProcess.StandardInput;
            cmdProcess.BeginOutputReadLine();
        }

        private void CmdProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (_isFirstRowDelete)
            {
                _isFirstRowDelete = false;
                return;
            }

            if (e.Data != null)
            {
                cmdOutput.Append(e.Data);

                this.Invoke(new MethodInvoker(() => {
                    textBox2.Text = cmdOutput.ToString();
                }));
            }
        }

        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            MessageBox.Show("프로세스가 종료되었습니다");
            Application.Exit();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                _isFirstRowDelete = true;
                cmdOutput.Clear();
                cmdStreamWriter.WriteLine(textBox1.Text);
                textBox1.Text = "";
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            cmdStreamWriter.Close();
            cmdProcess.WaitForExit();
            cmdProcess.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnExecute_Click(sender, EventArgs.Empty);
        }
    }
}
