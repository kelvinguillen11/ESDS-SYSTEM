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
    public partial class Control_m : Form
    {
        public Control_m()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox2, "Modificar");
            this.toolTip1.SetToolTip(this.pictureBox5, "Consultar");
            this.toolTip1.SetToolTip(this.pictureBox9, "Convertir a Excel");
            this.toolTip1.SetToolTip(this.pictureBox7, "Cargar Excel");
        }
        public void limpiar()
        {
            txtc.Clear();
        }
        public DataTable llenar_grid()
        {
            Conection.Conectar();
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM Asistencias";
            SqlCommand cmd = new SqlCommand(Consulta, Conection.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Menu_maestros m = new Menu_maestros();
            m.Show();
            this.Hide();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtc.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            dtp.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtg.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            txta.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            cmb4.Text = dgv.CurrentRow.Cells[4].Value.ToString();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            dgv.DataSource = llenar_grid();
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dgv);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (txtc.Text.Trim() != "" && dtp.Text.Trim() != "" && txtg.Text.Trim() != "" && txta.Text.Trim() != "" && cmb4.Text.Trim() != "")
            {
                Conection.Conectar();
                string actualizar = "UPDATE Asistencias SET Codigo_asistencia=@c, Fecha_asistencia=@f, Codigo_grado=@g, Carnet=@a, Control_asistencia=@ca WHERE  Codigo_asistencia=@c";
                SqlCommand cmd2 = new SqlCommand(actualizar, Conection.Conectar());
                cmd2.Parameters.AddWithValue("@c", txtc.Text);
                cmd2.Parameters.Add(new SqlParameter("@f", SqlDbType.Date));
                cmd2.Parameters["@f"].Value = dtp.Text;
                cmd2.Parameters.AddWithValue("@g", txtg.Text);
                cmd2.Parameters.AddWithValue("@a", txta.Text);
                cmd2.Parameters.AddWithValue("@ca", cmb4.Text);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Registro modificdo", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
                dgv.DataSource = llenar_grid();
            }
            else
            {
                MessageBox.Show("Campos Vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
