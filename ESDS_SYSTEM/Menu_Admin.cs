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
    public partial class Menu_Admin : Form
    {
        public Menu_Admin()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox5, "Administradores");
            this.toolTip1.SetToolTip(this.pictureBox7, "Maestros");
            this.toolTip1.SetToolTip(this.pictureBox14, "Grados");
            this.toolTip1.SetToolTip(this.pictureBox6, "Alumnos");
            this.toolTip1.SetToolTip(this.pictureBox3, "Asistencias");
            this.toolTip1.SetToolTip(this.pictureBox13, "Cerrar sesion");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            Alumnos a = new Alumnos();
            a.Show();
            this.Hide();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Alumnos a = new Alumnos();
            a.Show();
            this.Hide();
        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            Administradores ad = new Administradores();
            ad.Show();
            this.Hide();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Administradores ad = new Administradores();
            ad.Show();
            this.Hide();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Maestros ma = new Maestros();
            ma.Show();
            this.Hide();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Maestros ma = new Maestros();
            ma.Show();
            this.Hide();
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            Control cont = new Control();
            cont.Show();
            this.Hide();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Control cont = new Control();
            cont.Show();
            this.Hide();
        }

        private void PictureBox12_Click(object sender, EventArgs e)
        {
            Grados gr = new Grados();
            gr.Show();
            this.Hide();
        }

        private void PictureBox13_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void PictureBox14_Click(object sender, EventArgs e)
        {
            Grados gr = new Grados();
            gr.Show();
            this.Hide();
        }

        private void Menu_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
