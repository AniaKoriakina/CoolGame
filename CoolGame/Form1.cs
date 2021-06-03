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
        int enemySpeed = 5;
        int playerSpeed = 25;
        Image platfom = Properties.Resources.platform;
        Image spikes = Properties.Resources.spike;
        int viewX = 0;
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

        //private int Clamp(int value, int min,int max)
        //{
        //    if (value > max)
        //        return max;
        //    return value < min ? min : value;
        //}


        private void timer1_Tick(object sender, EventArgs e)
        {
            horMoveSpikes.Left -= horSpeed;
            if (horMoveSpikes.Left < 247 || horMoveSpikes.Left + horMoveSpikes.Width > this.ClientSize.Width)
            {
                horSpeed = -horSpeed;
            }
            horMoveSpikes.BringToFront();

            moveUpSpikes.Top += verSpeed;
            if (moveUpSpikes.Top < 610 || moveUpSpikes.Top > 1030)
            {
                verSpeed = -verSpeed;
            }
            moveUpSpikes.BringToFront();
        }

        

    }
}
