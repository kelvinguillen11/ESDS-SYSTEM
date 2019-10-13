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
    public partial class Grados : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string sCn;
        public Grados()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox2, "Modificar");
            this.toolTip1.SetToolTip(this.pictureBox3, "Eliminar");
            this.toolTip1.SetToolTip(this.pictureBox1, "Guardar");
            this.toolTip1.SetToolTip(this.pictureBox5, "Consultar");
            datos cn = new datos();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
        }
        public void limpiar()
        {
            txtc.Clear();
            txtn.Clear();
        }
        public DataTable llenar_grid()
        {
            Conection.Conectar();
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM Grados";
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
            Menu_Admin m = new Menu_Admin();
            m.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && cmb1.Text.Trim() != "" && cmb2.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string insertar = "INSERT INTO Grados(Codigo_grado, Nombre_grado, Codigo_maestro, Carnet) VALUES (@c, @n, @m, @a)";
                    SqlCommand cmd1 = new SqlCommand(insertar, Conection.Conectar());
                    cmd1.Parameters.AddWithValue("@c", txtc.Text);
                    cmd1.Parameters.AddWithValue("@n", txtn.Text);
                    cmd1.Parameters.AddWithValue("@m", cmb1.Text);
                    cmd1.Parameters.AddWithValue("@a", cmb2.Text);
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

        private void Grados_Load(object sender, EventArgs e)
        {
            SqlCommand commando = new SqlCommand("SELECT Codigo_maestro from Maestros", conn);
            conn.Open();
            SqlDataReader registro = commando.ExecuteReader();
            while (registro.Read())
            {
                cmb1.Items.Add(registro["Codigo_maestro"].ToString());
            }
            conn.Close();


            SqlCommand commando2 = new SqlCommand("SELECT Carnet from Alumnos", conn);
            conn.Open();
            SqlDataReader registro2 = commando2.ExecuteReader();
            while (registro2.Read())
            {
                cmb2.Items.Add(registro2["Carnet"].ToString());
            }
            conn.Close();
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtc.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            txtn.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            cmb1.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            cmb2.Text = dgv.CurrentRow.Cells[3].Value.ToString();
        }

        private void Txtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void Grados_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && cmb1.Text.Trim() != "" && cmb2.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string eliminar = "DELETE FROM Grados WHERE Codigo_grado=@c";
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
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && cmb1.Text.Trim() != "" && cmb2.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string actualizar = "UPDATE Grados SET Codigo_grado=@c, Nombre_grado=@n, Codigo_maestro=@m, Carnet=@a WHERE Codigo_grado=@c";
                    SqlCommand cmd2 = new SqlCommand(actualizar, Conection.Conectar());
                    cmd2.Parameters.AddWithValue("@c", txtc.Text);
                    cmd2.Parameters.AddWithValue("@n", txtn.Text);
                    cmd2.Parameters.AddWithValue("@m", cmb1.Text);
                    cmd2.Parameters.AddWithValue("@a", cmb2.Text);
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
