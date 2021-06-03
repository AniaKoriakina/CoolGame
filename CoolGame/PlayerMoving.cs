using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolGame
{
    public partial class Form1 : Form
    {
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
            if (e.KeyCode == Keys.D)
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
    }
}
