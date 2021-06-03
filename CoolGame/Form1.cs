using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolGame
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jump, gameover;
        int force;
        int gravity = 2;
        int jumpForce = 20;
        int horSpeed = 40;
        int verSpeed = 4;
        int playerSpeed = 25;
        int score = 30;

        public Form1()
        {
            Instructions i = new Instructions();
            i.ShowDialog();
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);
            KeyPreview = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitImage_MouseHover(object sender, EventArgs e)
        {
            exitImage.Image = Properties.Resources.exitImageMouse;
        }

        private void exitImage_MouseLeave(object sender, EventArgs e)
        {
            exitImage.Image = Properties.Resources.exitImage;
        }
    }
}
