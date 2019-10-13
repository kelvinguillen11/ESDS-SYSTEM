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
    public partial class Control : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string sCn;
        public Control()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox2, "Modificar");
            this.toolTip1.SetToolTip(this.pictureBox3, "Eliminar");
            this.toolTip1.SetToolTip(this.pictureBox1, "Guardar");
            this.toolTip1.SetToolTip(this.pictureBox5, "Consultar");
            this.toolTip1.SetToolTip(this.pictureBox7, "Convertir a Excel");
            this.toolTip1.SetToolTip(this.pictureBox9, "Cargar Excel");
            datos cn = new datos();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
        }
        public void limpiar()
        {
            
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
        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtc.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            dtp.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            cmb1.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            cmb3.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            cmb4.Text = dgv.CurrentRow.Cells[4].Value.ToString();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && dtp.Text.Trim() != "" && cmb1.Text.Trim() != "" && cmb3.Text.Trim() != "" && cmb4.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string insertar = "INSERT INTO Asistencias(Codigo_asistencia, Fecha_asistencia, Codigo_grado, Carnet, Control_asistencia) VALUES (@c, @f, @g, @a, @ca)";
                    SqlCommand cmd1 = new SqlCommand(insertar, Conection.Conectar());
                    cmd1.Parameters.AddWithValue("@c", txtc.Text);
                    cmd1.Parameters.Add(new SqlParameter("@f", SqlDbType.Date));
                    cmd1.Parameters["@f"].Value = dtp.Text;
                    cmd1.Parameters.AddWithValue("@g", cmb1.Text);
                    cmd1.Parameters.AddWithValue("@a", cmb3.Text);
                    cmd1.Parameters.AddWithValue("@ca", cmb4.Text);
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

        private void Control_Load(object sender, EventArgs e)
        {
            SqlCommand commando3 = new SqlCommand("SELECT Codigo_grado from Grados", conn);
            conn.Open();
            SqlDataReader registro3 = commando3.ExecuteReader();
            while (registro3.Read())
            {
                cmb1.Items.Add(registro3["Codigo_grado"].ToString());
            }
            conn.Close();


            SqlCommand commando2 = new SqlCommand("SELECT Carnet from Alumnos", conn);
            conn.Open();
            SqlDataReader registro2 = commando2.ExecuteReader();
            while (registro2.Read())
            {
                cmb3.Items.Add(registro2["Carnet"].ToString());
            }
            conn.Close();
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            Exportar exp = new Exportar();
            exp.ExportarDataGridViewExcel(dgv);
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

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && dtp.Text.Trim() != "" && cmb1.Text.Trim() != "" && cmb3.Text.Trim() != "" && cmb4.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string eliminar = "DELETE FROM Asistencias WHERE Codigo_asistencia=@c";
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
                if (txtc.Text.Trim() != "" && dtp.Text.Trim() != "" && cmb1.Text.Trim() != "" && cmb3.Text.Trim() != "" && cmb4.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string actualizar = "UPDATE Asistencias SET Codigo_asistencia=@c, Fecha_asistencia=@f, Codigo_grado=@g, Carnet=@a, Control_asistencia=@ca WHERE  Codigo_asistencia=@c";
                    SqlCommand cmd2 = new SqlCommand(actualizar, Conection.Conectar());
                    cmd2.Parameters.AddWithValue("@c", txtc.Text);
                    cmd2.Parameters.Add(new SqlParameter("@f", SqlDbType.Date));
                    cmd2.Parameters["@f"].Value = dtp.Text;
                    cmd2.Parameters.AddWithValue("@g", cmb1.Text);
                    cmd2.Parameters.AddWithValue("@a", cmb3.Text);
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
            catch (Exception error)
            {
                MessageBox.Show("Algo salio mal", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
