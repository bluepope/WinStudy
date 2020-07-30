using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            this.Load += Form3_Load;

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            var btn = new PictureBox();
            btn.BackgroundImage = Image.FromFile("d:/1.png");
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Click += (s, evt) => {
                foreach(var item in btn.Parent.Controls)
                {
                    (item as PictureBox).BackColor = Color.White;
                }
                btn.BackColor = Color.Red;

                panel1.Controls.Clear();
                panel1.Controls.Add(new Button() { Text = "btn1" });
            };
            flowLayoutPanel1.Controls.Add(btn);

            btn = new PictureBox();
            btn.BackgroundImage = Image.FromFile("d:/18.jpg");
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Click += (s, evt) => {
                foreach (var item in btn.Parent.Controls)
                {
                    (item as PictureBox).BackColor = Color.White;
                }
                btn.BackColor = Color.Red;

                panel1.Controls.Clear();
                panel1.Controls.Add(new Button() { Text = "btn2" });
            };

            flowLayoutPanel1.Controls.Add(btn);
        }
    }
}
