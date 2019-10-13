using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESDS_SYSTEM
{
    public partial class Creditos : Form
    {
        public Creditos()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox5, "Administrador");
            this.toolTip1.SetToolTip(this.pictureBox7, "Maestro");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Login2 lg2 = new Login2();
            lg2.Show();
            this.Hide();
        }
    }
}
