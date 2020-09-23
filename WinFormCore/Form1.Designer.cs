namespace WinFormCore
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.popeButton5 = new WinFormCore.Controls.PopeButton();
            this.popeButton4 = new WinFormCore.Controls.PopeButton();
            this.popeButton3 = new WinFormCore.Controls.PopeButton();
            this.popeButton2 = new WinFormCore.Controls.PopeButton();
            this.popeButton1 = new WinFormCore.Controls.PopeButton();
            this.popeGrid1 = new WinFormCore.Controls.PopeGrid();
            this.popeButton6 = new WinFormCore.Controls.PopeButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popeGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.popeButton6);
            this.panel1.Controls.Add(this.popeButton5);
            this.panel1.Controls.Add(this.popeButton4);
            this.panel1.Controls.Add(this.popeButton3);
            this.panel1.Controls.Add(this.popeButton2);
            this.panel1.Controls.Add(this.popeButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(721, 66);
            this.panel1.TabIndex = 2;
            // 
            // popeButton5
            // 
            this.popeButton5.Location = new System.Drawing.Point(476, 12);
            this.popeButton5.Name = "popeButton5";
            this.popeButton5.Size = new System.Drawing.Size(84, 41);
            this.popeButton5.TabIndex = 1;
            this.popeButton5.Text = "Delete";
            this.popeButton5.UseVisualStyleBackColor = true;
            this.popeButton5.Click += new System.EventHandler(this.popeButton5_Click);
            // 
            // popeButton4
            // 
            this.popeButton4.Location = new System.Drawing.Point(384, 12);
            this.popeButton4.Name = "popeButton4";
            this.popeButton4.Size = new System.Drawing.Size(86, 41);
            this.popeButton4.TabIndex = 1;
            this.popeButton4.Text = "Add";
            this.popeButton4.UseVisualStyleBackColor = true;
            this.popeButton4.Click += new System.EventHandler(this.popeButton4_Click);
            // 
            // popeButton3
            // 
            this.popeButton3.Location = new System.Drawing.Point(260, 12);
            this.popeButton3.Name = "popeButton3";
            this.popeButton3.Size = new System.Drawing.Size(118, 41);
            this.popeButton3.TabIndex = 1;
            this.popeButton3.Text = "Task 10 Time";
            this.popeButton3.UseVisualStyleBackColor = true;
            this.popeButton3.Click += new System.EventHandler(this.popeButton3_Click);
            // 
            // popeButton2
            // 
            this.popeButton2.Location = new System.Drawing.Point(136, 12);
            this.popeButton2.Name = "popeButton2";
            this.popeButton2.Size = new System.Drawing.Size(118, 41);
            this.popeButton2.TabIndex = 1;
            this.popeButton2.Text = "cellChange";
            this.popeButton2.UseVisualStyleBackColor = true;
            this.popeButton2.Click += new System.EventHandler(this.popeButton2_Click);
            // 
            // popeButton1
            // 
            this.popeButton1.Location = new System.Drawing.Point(12, 12);
            this.popeButton1.Name = "popeButton1";
            this.popeButton1.Size = new System.Drawing.Size(118, 41);
            this.popeButton1.TabIndex = 1;
            this.popeButton1.Text = "rowChange";
            this.popeButton1.UseVisualStyleBackColor = true;
            this.popeButton1.Click += new System.EventHandler(this.popeButton1_Click);
            // 
            // popeGrid1
            // 
            this.popeGrid1.AllowUserToAddRows = false;
            this.popeGrid1.AllowUserToDeleteRows = false;
            this.popeGrid1.AllowUserToOrderColumns = true;
            this.popeGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.popeGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popeGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.popeGrid1.Location = new System.Drawing.Point(0, 66);
            this.popeGrid1.Name = "popeGrid1";
            this.popeGrid1.Size = new System.Drawing.Size(721, 323);
            this.popeGrid1.TabIndex = 0;
            this.popeGrid1.Text = "popeGrid1";
            // 
            // popeButton6
            // 
            this.popeButton6.Location = new System.Drawing.Point(566, 12);
            this.popeButton6.Name = "popeButton6";
            this.popeButton6.Size = new System.Drawing.Size(84, 41);
            this.popeButton6.TabIndex = 1;
            this.popeButton6.Text = "Save";
            this.popeButton6.UseVisualStyleBackColor = true;
            this.popeButton6.Click += new System.EventHandler(this.popeButton6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 389);
            this.Controls.Add(this.popeGrid1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popeGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Controls.PopeButton popeButton1;
        private Controls.PopeGrid popeGrid1;
        private Controls.PopeButton popeButton2;
        private Controls.PopeButton popeButton3;
        private Controls.PopeButton popeButton4;
        private Controls.PopeButton popeButton5;
        private Controls.PopeButton popeButton6;
    }
}

