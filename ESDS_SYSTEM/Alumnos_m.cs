using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ESDS_SYSTEM
{
    public partial class Alumnos_m : Form
    {
        public Alumnos_m()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox5, "Consultar");
            this.toolTip1.SetToolTip(this.pictureBox7, "Convertir a Excel");
            this.toolTip1.SetToolTip(this.pictureBox9, "Cargar Excel");
        }
        public void limpiar()
        {
            txtc.Clear();
            txtn.Clear();
            txta.Clear();
        }
        public DataTable llenar_grid()
        {
            Conection.Conectar();
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM Alumnos";
            SqlCommand cmd = new SqlCommand(Consulta, Conection.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Menu_maestros m = new Menu_maestros();
            m.Show();
            this.Hide();
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtc.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtn.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txta.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            dtp.Text = dgv.CurrentRow.Cells[3].Value.ToString();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            dgv.DataSource = llenar_grid();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dgv);
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            
        }
    }
}
