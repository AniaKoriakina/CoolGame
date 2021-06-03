using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolGame
{
    public partial class Form1
    {
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
