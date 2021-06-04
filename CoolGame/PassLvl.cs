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
    public partial class PassLvl : Form
    {
        private Form1 form2;
        public PassLvl(Form1 form2)
        {
            InitializeComponent();
            this.form2 = form2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
            form2.Close();
        }
    }
}
