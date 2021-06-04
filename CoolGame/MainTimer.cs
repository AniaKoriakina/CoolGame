using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolGame
{
    partial class Form1 : Form
    {
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
            if (jump == true)
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
                            SurfaceLimit(x);
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
                    if ((string)x.Tag == "runeBag" && x.Visible == true)
                    {
                        if ((player.Bounds.IntersectsWith(x.Bounds)))
                        {
                            x.Visible = false;
                            score--;
                            System.Media.SoundPlayer take = new System.Media.SoundPlayer(Properties.Resources.take);
                            take.Play();
                        }
                    }

                }
            }
            if (player.Bounds.IntersectsWith(wormhole.Bounds) && score == 0)
            {
                System.Media.SoundPlayer win = new System.Media.SoundPlayer(Properties.Resources.win);
                win.Play();
                mainTimer.Stop();
                gameover = true;
                player.Visible = false;
                PassLvl passLvl = new PassLvl(this);
                passLvl.Show();
            }



            //viewX = Clamp(viewX, 0, map.Length * 80 - 850);

        }

        private void SurfaceLimit(Control x)
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
    }
}
