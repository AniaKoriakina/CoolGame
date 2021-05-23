using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoolGame
{
    public partial class GameOver : Form
    {
        private Form1 form1;
        public GameOver(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            form1.RestartGame();
            Close();
        }

        private void GameOver_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Close();
        }
    }
}
