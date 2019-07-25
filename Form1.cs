using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace deneme2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Location = new Point(14, 440);

        }
        int x, y, z, sayac, gidilenyol;
        int toplamcan = 1;
        int kalancan=1;
        Random rnd = new Random();

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            y = pictureBox1.Location.Y;
            x = pictureBox1.Location.X;
            if (e.KeyCode == Keys.Right && x < 400)
            {
                sagagit();
            }
            if (e.KeyCode == Keys.Left && x > 0)
            {
                solagit();
            }
            pictureBox1.Location = new Point(x, y);

            if (e.KeyCode == Keys.Space)
            {
                mermiOlustur();

            }

        }
        void YeniOyun()
        {
            gidilenyol = 0;            
        }
        void sagagit()
        {
            x += 5;
        }
        void solagit()
        {
            x -= 5;
        }
        private void dusmanOlustur()
        {
            z = rnd.Next(0, 420);
            PictureBox dusman = new PictureBox();
            dusman.Size = new Size(20, 20);
            dusman.ImageLocation = "dusman.png";
            dusman.Location = new Point(z, 0);
            dusman.SizeMode = PictureBoxSizeMode.StretchImage;
            dusman.Tag = "dusman";
            this.Controls.Add(dusman);
            panel1.Controls.Add(dusman);
        }
        private void mermiOlustur()
        {
            PictureBox mermi = new PictureBox();
            mermi.Size = new Size(15,15);
            mermi.ImageLocation = "füze.png";
            mermi.Location = new Point(x+14, y - 10);
            mermi.SizeMode = PictureBoxSizeMode.StretchImage;
            mermi.Tag = "mermi";
            this.Controls.Add(mermi);
            panel1.Controls.Add(mermi);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            progressBar1.Value = 100 / toplamcan * kalancan;
            label1.Text = "Gidilen Yol:" + gidilenyol.ToString() + "m";
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                PictureBox pb = ((PictureBox)panel1.Controls[i]);
                if (panel1.Controls[i].Tag == "mermi")
                {
                    pb.Location = new Point(pb.Location.X, pb.Location.Y - 15);

                }
                for (int a = 0; a < panel1.Controls.Count; a++)
                {
                    if (panel1.Controls[a].Tag == "dusman")
                    {
                        if (pb.Location.X + pb.Width > panel1.Controls[a].Location.X && pb.Location.X + pb.Width < panel1.Controls[a].Location.X + panel1.Controls[a].Width)
                        {
                            if (pb.Location.Y + pb.Height > panel1.Controls[a].Location.Y && pb.Location.Y + pb.Height < panel1.Controls[a].Location.Y + panel1.Controls[a].Height)
                            {
                                panel1.Controls.RemoveAt(a);
                                panel1.Controls.Remove(pb);

                            }
                        }
                        if(panel1.Controls[a].Location.Y==440 && panel1.Controls[a].Location.Y==y)
                        {
                            YeniOyun();
                        }
                    }


                }
                if (panel1.Controls[i].Tag == "dusman")
                {
                    pb.Location = new Point(pb.Location.X, pb.Location.Y + 8);

                }
            }

            if (sayac % 10 == 0)
            {
                gidilenyol++;
                dusmanOlustur();
            }
            
        }
     }
}
       
   

