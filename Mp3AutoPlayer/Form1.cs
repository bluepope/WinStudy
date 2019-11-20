using Mp3AutoPlayer.Models;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Mp3AutoPlayer
{
    public partial class Form1 : Form
    {
        Mp3Player Player { get; } = new Mp3Player();

        string _mainPath = System.IO.Path.Combine(Environment.CurrentDirectory, "PlayList");
            
        public Form1()
        {
            InitializeComponent();

            Init();
            this.ReserveTimer.Enabled = false;

            this.StartTime.Text = "15:50";
            this.EndTime.Text = "16:00";
            this.RandomCheck.Checked = true;

            lblMainPath.Text = _mainPath;

            this.Player.PlayEnded += Player_PlayEnded;
            this.Mp3Trackbar.Minimum = 0;
        }

        private void Player_PlayEnded(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (FileList.Items.Count > FileList.SelectedIndex + 1)
                {
                    FileList.SelectedIndex = FileList.SelectedIndex + 1;

                    this.Mp3Trackbar.Value = 0;
                    Player.Play(System.IO.Path.Combine(_mainPath, FolderList.SelectedItem.ToString(), FileList.SelectedItem.ToString()));
                    this.Mp3Trackbar.Maximum = (int)this.Player.TotalTime.TotalSeconds;
                }
                else
                {
                    FileList.SelectedIndex = 0;
                    Player.Stop();
                }
            }));
        }

        public void Init()
        {
            FolderList.Items.Clear();
            FileList.Items.Clear();

            if (System.IO.Directory.Exists(_mainPath) == false)
            {
                System.IO.Directory.CreateDirectory(_mainPath);
                return;
            }

            foreach (var item in System.IO.Directory.EnumerateDirectories(_mainPath, "*", System.IO.SearchOption.TopDirectoryOnly))
            {
                FolderList.Items.Add(item.Substring(item.LastIndexOf('\\') + 1));
            }

            if (FolderList.Items.Count > 0)
                FolderList.SelectedIndex = 0;
        }

        void NowSwitch(bool flag)
        {
            if (flag)
                btnNow.Text = "즉시 재생";
            else
                btnNow.Text = "즉시 중지";

            FolderList.Enabled = flag;
            FileList.Enabled = flag;
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            if (Player.PlayStatus == PlaybackState.Playing)
            {
                Player.Stop();
                NowSwitch(true);
            }
            else
            {
                if (FolderList.SelectedIndex < 0)
                {
                    if (FolderList.Items.Count > 0)
                    {
                        FolderList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("플레이 폴더가 없습니다");
                        return;
                    }
                }

                if (FileList.SelectedIndex < 0)
                {
                    if (FileList.Items.Count > 0)
                    {
                        FileList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("플레이 파일이 없습니다");
                        return;
                    }
                }

                this.Mp3Trackbar.Value = 0;
                Player.Play(System.IO.Path.Combine(_mainPath, FolderList.SelectedItem.ToString(), FileList.SelectedItem.ToString()));
                this.Mp3Trackbar.Maximum = (int)this.Player.TotalTime.TotalSeconds;
                NowSwitch(false);
            }
        }

        private void FolderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileList.Items.Clear();

            if (FolderList.SelectedIndex < 0)
                return;

            foreach(var item in System.IO.Directory.GetFiles(System.IO.Path.Combine(_mainPath, FolderList.SelectedItem.ToString()), "*.mp3"))
            {
                FileList.Items.Add(System.IO.Path.GetFileName(item));
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (ReserveTimer.Enabled)
            {
                btnReserve.Text = "예약설정";
                ReserveTimer.Enabled = false;
                StartTime.Enabled = true;
                EndTime.Enabled = true;
                RandomCheck.Enabled = true;
            }
            else
            {
                if (FolderList.SelectedIndex < 0)
                {
                    if (FolderList.Items.Count > 0)
                    {
                        FolderList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("플레이 폴더가 없습니다");
                        return;
                    }
                }

                if (FileList.SelectedIndex < 0)
                {
                    if (FileList.Items.Count > 0)
                    {
                        FileList.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("플레이 파일이 없습니다");
                        return;
                    }
                }

                btnReserve.Text = "예약중지";
                ReserveTimer.Enabled = true;
                StartTime.Enabled = false;
                EndTime.Enabled = false;
                RandomCheck.Enabled = false;
            }
        }

        private void ReserveTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now.ToString("HH:mm");

            if (now == StartTime.Text && Player.PlayStatus != PlaybackState.Playing)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    var date = DateTime.Today.ToString("yyyyMMdd");

                    if (RandomCheck.Checked)
                    {
                        //동기화를 위한 시드값 설정
                        var seed = Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd").Replace("-", "").Replace("/", ""));

                        FolderList.SelectedIndex = new Random(seed).Next(FolderList.Items.Count);
                    }

                    FileList.SelectedIndex = 0;

                    this.Mp3Trackbar.Value = 0;

                    Player.Play(System.IO.Path.Combine(_mainPath, FolderList.SelectedItem.ToString(), FileList.SelectedItem.ToString()));
                    this.Mp3Trackbar.Maximum = (int)this.Player.TotalTime.TotalSeconds;
                    NowSwitch(false);
                }));
            }
            else if (now == EndTime.Text && Player.PlayStatus == PlaybackState.Playing)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    Player.Stop();
                    NowSwitch(true);
                }));
            }
        }

        private void PlayTimer_Tick(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() => {
                lblNowTime.Text = DateTime.Now.ToString("hh:mm:ss");

                if (Player.PlayStatus == PlaybackState.Playing)
                {
                    Mp3TimeLabel.Text = $"{Player.CurrentTime.Minutes.ToString("00")}:{Player.CurrentTime.Seconds.ToString("00")} / {Player.TotalTime.Minutes.ToString("00")}:{Player.TotalTime.Seconds.ToString("00")}";
                    Mp3Trackbar.Value = (int)Player.CurrentTime.TotalSeconds;
                }
            }));
        }

        public string GetHtmlSource(string url, Encoding encoding)
        {
            string r = string.Empty;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 11.0; Windows NT 6.1; Trident/6.0)";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
                {
                    r = sr.ReadToEnd();
                }
            }

            return r;
        }

        private void Mp3Trackbar_Scroll(object sender, EventArgs e)
        {
            Player.CurrentTime = TimeSpan.FromSeconds((sender as TrackBar).Value);
        }
    }
}
