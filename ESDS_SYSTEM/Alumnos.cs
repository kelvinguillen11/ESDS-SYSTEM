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
    public partial class Alumnos : Form
    {
        
        public Alumnos()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox2, "Modificar");
            this.toolTip1.SetToolTip(this.pictureBox3, "Eliminar");
            this.toolTip1.SetToolTip(this.pictureBox1, "Guardar");
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
        private void Alumnos_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Menu_Admin m = new Menu_Admin();
            m.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && txta.Text.Trim() != "" && dtp.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string insertar = "INSERT INTO Alumnos(Carnet, Nombre_alumno, Apellido_alumno, Fecha_nacimineto) VALUES (@c, @n, @a, @f)";
                    SqlCommand cmd1 = new SqlCommand(insertar, Conection.Conectar());
                    cmd1.Parameters.AddWithValue("@c", txtc.Text);
                    cmd1.Parameters.AddWithValue("@n", txtn.Text);
                    cmd1.Parameters.AddWithValue("@a", txta.Text);
                    cmd1.Parameters.Add(new SqlParameter("@f", SqlDbType.Date));
                    cmd1.Parameters["@f"].Value = dtp.Text;
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Registro agregado", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    dgv.DataSource = llenar_grid();
                }
                else
                {
                    MessageBox.Show("Campos Vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Algo salio mal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            dgv.DataSource = llenar_grid();
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtc.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtn.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txta.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            dtp.Text = dgv.CurrentRow.Cells[3].Value.ToString();
        }

        private void Txtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void Txta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void Alumnos_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dgv);
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && txta.Text.Trim() != "" && dtp.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string eliminar = "DELETE FROM Alumnos WHERE Carnet=@c";
                    SqlCommand cmd3 = new SqlCommand(eliminar, Conection.Conectar());
                    cmd3.Parameters.AddWithValue("@c", txtc.Text);
                    cmd3.ExecuteNonQuery();
                    MessageBox.Show("Registro eliminado", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar();
                    dgv.DataSource = llenar_grid();
                }
                else
                {
                    MessageBox.Show("Campos Vacios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Algo salio mal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && txta.Text.Trim() != "" && dtp.Text.Trim() != "")
                {

                    Conection.Conectar();
                    string actualizar = "UPDATE Alumnos SET Carnet=@c, Nombre_alumno=@n, Apellido_alumno=@a, Fecha_nacimineto=@f WHERE Carnet=@c";
                    SqlCommand cmd2 = new SqlCommand(actualizar, Conection.Conectar());
                    cmd2.Parameters.AddWithValue("@c", txtc.Text);
                    cmd2.Parameters.AddWithValue("@n", txtn.Text);
                    cmd2.Parameters.AddWithValue("@a", txta.Text);
                    cmd2.Parameters.Add(new SqlParameter("@f", SqlDbType.Date));
                    cmd2.Parameters["@f"].Value = dtp.Text;
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
            catch (Exception error)
            {
                MessageBox.Show("Algo salio mal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
