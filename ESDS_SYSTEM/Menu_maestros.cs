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
    public partial class Menu_maestros : Form
    {
        public Menu_maestros()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox6, "Alumnos");
            this.toolTip1.SetToolTip(this.pictureBox3, "Asistencias");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_maestros_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            Login2 lg = new Login2();
            lg.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Login2 lg = new Login2();
            lg.Show();
            this.Hide();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Alumnos_m am = new Alumnos_m();
            am.Show();
            this.Hide();
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            Alumnos_m am = new Alumnos_m();
            am.Show();
            this.Hide();
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            Control_m cm = new Control_m();
            cm.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Control_m cm = new Control_m();
            cm.Show();
            this.Hide();
        }
    }
}
