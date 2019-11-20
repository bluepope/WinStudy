namespace Mp3AutoPlayer
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMainPath = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RandomCheck = new System.Windows.Forms.CheckBox();
            this.btnNow = new System.Windows.Forms.Button();
            this.EndTime = new System.Windows.Forms.MaskedTextBox();
            this.StartTime = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReserve = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.FileList = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.FolderList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNowTime = new System.Windows.Forms.Label();
            this.Mp3Trackbar = new System.Windows.Forms.TrackBar();
            this.Mp3TimeLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ReserveTimer = new System.Windows.Forms.Timer(this.components);
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mp3Trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMainPath);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.RandomCheck);
            this.groupBox1.Controls.Add(this.btnNow);
            this.groupBox1.Controls.Add(this.EndTime);
            this.groupBox1.Controls.Add(this.StartTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnReserve);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "설정";
            // 
            // lblMainPath
            // 
            this.lblMainPath.AutoSize = true;
            this.lblMainPath.Location = new System.Drawing.Point(117, 48);
            this.lblMainPath.Name = "lblMainPath";
            this.lblMainPath.Size = new System.Drawing.Size(11, 12);
            this.lblMainPath.TabIndex = 9;
            this.lblMainPath.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "플레이리스트 폴더";
            // 
            // RandomCheck
            // 
            this.RandomCheck.AutoSize = true;
            this.RandomCheck.Location = new System.Drawing.Point(318, 20);
            this.RandomCheck.Name = "RandomCheck";
            this.RandomCheck.Size = new System.Drawing.Size(112, 16);
            this.RandomCheck.TabIndex = 7;
            this.RandomCheck.Text = "랜덤폴더 플레이";
            this.RandomCheck.UseVisualStyleBackColor = true;
            // 
            // btnNow
            // 
            this.btnNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNow.Location = new System.Drawing.Point(514, 17);
            this.btnNow.Name = "btnNow";
            this.btnNow.Size = new System.Drawing.Size(65, 21);
            this.btnNow.TabIndex = 6;
            this.btnNow.Text = "즉시시작";
            this.btnNow.UseVisualStyleBackColor = true;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // EndTime
            // 
            this.EndTime.Location = new System.Drawing.Point(221, 17);
            this.EndTime.Mask = "00:00";
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(91, 21);
            this.EndTime.TabIndex = 5;
            // 
            // StartTime
            // 
            this.StartTime.Location = new System.Drawing.Point(65, 17);
            this.StartTime.Mask = "00:00";
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(91, 21);
            this.StartTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "종료시간";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "시작시간";
            // 
            // btnReserve
            // 
            this.btnReserve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReserve.Location = new System.Drawing.Point(436, 17);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(72, 21);
            this.btnReserve.TabIndex = 1;
            this.btnReserve.Text = "예약설정";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 508);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "플레이리스트 (Playlist 폴더를 자동으로 읽어옵니다)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.FileList);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(134, 107);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(448, 398);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "파일 리스트";
            // 
            // FileList
            // 
            this.FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList.FormattingEnabled = true;
            this.FileList.ItemHeight = 12;
            this.FileList.Items.AddRange(new object[] {
            "ㅁㅁㅁ",
            "ㅁㅁㅁㄴ"});
            this.FileList.Location = new System.Drawing.Point(3, 17);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(442, 378);
            this.FileList.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FolderList);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 398);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "폴더";
            // 
            // FolderList
            // 
            this.FolderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderList.FormattingEnabled = true;
            this.FolderList.ItemHeight = 12;
            this.FolderList.Items.AddRange(new object[] {
            "ㅁㅁㅁ",
            "ㅁㅁㅁㄴ"});
            this.FolderList.Location = new System.Drawing.Point(3, 17);
            this.FolderList.Name = "FolderList";
            this.FolderList.Size = new System.Drawing.Size(125, 378);
            this.FolderList.TabIndex = 0;
            this.FolderList.SelectedIndexChanged += new System.EventHandler(this.FolderList_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNowTime);
            this.panel1.Controls.Add(this.Mp3Trackbar);
            this.panel1.Controls.Add(this.Mp3TimeLabel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 90);
            this.panel1.TabIndex = 0;
            // 
            // lblNowTime
            // 
            this.lblNowTime.AutoSize = true;
            this.lblNowTime.Location = new System.Drawing.Point(9, 64);
            this.lblNowTime.Name = "lblNowTime";
            this.lblNowTime.Size = new System.Drawing.Size(49, 12);
            this.lblNowTime.TabIndex = 10;
            this.lblNowTime.Text = "15:26:01";
            // 
            // Mp3Trackbar
            // 
            this.Mp3Trackbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Mp3Trackbar.Location = new System.Drawing.Point(98, 31);
            this.Mp3Trackbar.Maximum = 100;
            this.Mp3Trackbar.Name = "Mp3Trackbar";
            this.Mp3Trackbar.Size = new System.Drawing.Size(472, 45);
            this.Mp3Trackbar.TabIndex = 3;
            this.Mp3Trackbar.Scroll += new System.EventHandler(this.Mp3Trackbar_Scroll);
            // 
            // Mp3TimeLabel
            // 
            this.Mp3TimeLabel.AutoSize = true;
            this.Mp3TimeLabel.Location = new System.Drawing.Point(9, 31);
            this.Mp3TimeLabel.Name = "Mp3TimeLabel";
            this.Mp3TimeLabel.Size = new System.Drawing.Size(75, 12);
            this.Mp3TimeLabel.TabIndex = 2;
            this.Mp3TimeLabel.Text = "01:10 / 03:10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "재생파일명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "재생중인 파일:";
            // 
            // ReserveTimer
            // 
            this.ReserveTimer.Interval = 1000;
            this.ReserveTimer.Tick += new System.EventHandler(this.ReserveTimer_Tick);
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.PlayTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 583);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "음악재생기";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mp3Trackbar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox RandomCheck;
        private System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.MaskedTextBox EndTime;
        private System.Windows.Forms.MaskedTextBox StartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox FileList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox FolderList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar Mp3Trackbar;
        private System.Windows.Forms.Label Mp3TimeLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer ReserveTimer;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Label lblNowTime;
        private System.Windows.Forms.Label lblMainPath;
        private System.Windows.Forms.Label label5;
    }
}

