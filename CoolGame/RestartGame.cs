using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolGame
{
    partial class Form1 : Form
    {
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
