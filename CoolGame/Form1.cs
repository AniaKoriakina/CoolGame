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

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            Point cursor = PointToClient(Cursor.Position);
            //if (cursor.X < 50)
            //    viewX-=10;
            //else if (cursor.X > 750)
            //    viewX+=10;
            label1.Text = cursor.ToString();
            countBags.Text = "collected " + score + " runebags to get through";
            if (goRight == true)
            {
                player.Left += playerSpeed;
            }
            if (goLeft == true)
            {
                player.Left -= playerSpeed;
            }
            if(jump == true)
            {
                player.Top -= force;
                force -= gravity;
            }
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            if (player.Bottom >= x.Top + 2 && player.Top <= x.Bottom - 2)
                            {
                                if (player.Right >= x.Left && player.Left <= x.Left)
                                    player.Left = x.Left - player.Width - 1;
                                else if (player.Left <= x.Right && player.Right >= x.Right)
                                    player.Left = x.Right + 1;
                                else if (player.Top <= x.Bottom && player.Bottom >= x.Bottom)
                                {
                                    player.Top = x.Bottom + 1;
                                    force = 0;
                                }
                                else if (player.Bottom >= x.Top && player.Top < x.Top)
                                {
                                    player.Top = x.Top - player.Height - 1;
                                    force = 0;
                                }
                            }
                            else if (player.Top <= x.Bottom && player.Bottom >= x.Bottom)
                            {
                                player.Top = x.Bottom + 1;
                                force = 0;
                            }
                            else if (player.Bottom >= x.Top && player.Top < x.Top)
                            {
                                player.Top = x.Top - player.Height - 1;
                                force = 0;
                            }
                    }
                        x.BringToFront();
                    }
                    if ((string)x.Tag == "enemy" || (string)x.Tag == "spikes")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            System.Media.SoundPlayer dead = new System.Media.SoundPlayer(Properties.Resources.dead);
                            dead.Play();
                            mainTimer.Stop();
                            gameover = true;
                            player.Visible = false;
                            //label2.Text = "press ENTER to restart";
                            GameOver g = new GameOver(this);
                            g.ShowDialog();
                        }
                    }
                    if((string)x.Tag == "runeBag" && x.Visible == true)
                    {
                        if ((player.Bounds.IntersectsWith(x.Bounds)))
                        {
                            x.Visible = false;
                            score--; 
                        }
                    }

                }
            }
            if (player.Bounds.IntersectsWith(wormhole.Bounds) && score == 0)
            {
                mainTimer.Stop();
                gameover = true;
                player.Visible = false;
                PassLvl passLvl = new PassLvl();
                passLvl.Show();
            }
            


            //viewX = Clamp(viewX, 0, map.Length * 80 - 850);

        }


        private int Clamp(int value, int min,int max)
        {
            if (value > max)
                return max;
            return value < min ? min : value;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            horMoveSpikes.Left -= horSpeed;
            if (horMoveSpikes.Left < 247 || horMoveSpikes.Left + horMoveSpikes.Width > this.ClientSize.Width)
            {
                horSpeed = -horSpeed;
            }
            horMoveSpikes.BringToFront();

            moveUpSpikes.Top += verSpeed;
            if (moveUpSpikes.Top < 610 || moveUpSpikes.Top > 1081)
            {
                verSpeed = -verSpeed;
            }
            moveUpSpikes.BringToFront();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    goLeft = true;
                    player.Image = CoolGame.Properties.Resources.PlayerGr;
                    break;
                case Keys.D:
                    goRight = true;
                    player.Image = CoolGame.Properties.Resources.PlayerG2;
                    break;
            }
            if (player.Location.Y > 0)
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    force = jumpForce;
                }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.D)
                goRight = false;
            if (e.KeyCode == Keys.A)
                goLeft = false;
            if (e.KeyCode == Keys.Space && jump == false)
            {
                jump = false;
            }
            if (e.KeyCode == Keys.Enter && gameover == true)
            {
                //label2.Text = "";
                RestartGame();
            }
        }
        public void RestartGame()
        {

            jump = false;
            goLeft = false;
            goRight = false;
            gameover = false;
            player.Visible = true;
            score = 30;
            player.Left = 55;
            player.Top = 924;
            horMoveSpikes.Left = 317;
            enemyOne.Left = 1302;
            enemyTwo.Left = 611;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
            mainTimer.Start();
        }

    }
}
