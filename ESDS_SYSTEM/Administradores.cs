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
    public partial class Administradores : Form
    {
        
        public Administradores()
        {
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox2, "Modificar");
            this.toolTip1.SetToolTip(this.pictureBox3, "Eliminar");
            this.toolTip1.SetToolTip(this.pictureBox1, "Guardar");
            this.toolTip1.SetToolTip(this.pictureBox5, "Consultar");
        }
        public void limpiar()
        {
            txtc.Clear();
            txtn.Clear();
            txta.Clear();
            txtce.Clear();
            txtu.Clear();
            txtcl.Clear();
        }
        public DataTable llenar_grid()
        {
            Conection.Conectar();
            DataTable dt = new DataTable();
            string Consulta = "SELECT * FROM Administradores";
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
        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && txta.Text.Trim() != "" && txtce.Text.Trim() != "" && txtu.Text.Trim() != "" && txtcl.Text.Trim() != "")
                {
                    if (email_bien_escrito(txtce.Text))
                    {

                        Conection.Conectar();
                        string insertar = "INSERT INTO Administradores(Codigo_administrador, Nombre_administrador, Apellido_administrador, Correo_administrador, Alias_administrador, Clave_administrador) VALUES (@c, @n, @a, @ce, @u, @cl)";
                        SqlCommand cmd1 = new SqlCommand(insertar, Conection.Conectar());
                        cmd1.Parameters.AddWithValue("@c", txtc.Text);
                        cmd1.Parameters.AddWithValue("@n", txtn.Text);
                        cmd1.Parameters.AddWithValue("@a", txta.Text);
                        cmd1.Parameters.AddWithValue("@ce", txtce.Text);
                        cmd1.Parameters.AddWithValue("@u", txtu.Text);
                        cmd1.Parameters.AddWithValue("@cl", txtcl.Text);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Registro agregado", "HECHO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                        dgv.DataSource = llenar_grid();
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un correo electronico valido", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
            txtce.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            txtu.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            txtcl.Text = dgv.CurrentRow.Cells[5].Value.ToString();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && txta.Text.Trim() != "" && txtce.Text.Trim() != "" && txtu.Text.Trim() != "" && txtcl.Text.Trim() != "")
                {
                    Conection.Conectar();
                    string actualizar = "UPDATE Administradores SET Codigo_administrador=@c, Nombre_administrador=@n, Apellido_administrador=@a, Correo_administrador=@ce, Alias_administrador=@u, Clave_administrador=@cl WHERE Codigo_administrador=@c";
                    SqlCommand cmd2 = new SqlCommand(actualizar, Conection.Conectar());
                    cmd2.Parameters.AddWithValue("@c", txtc.Text);
                    cmd2.Parameters.AddWithValue("@n", txtn.Text);
                    cmd2.Parameters.AddWithValue("@a", txta.Text);
                    cmd2.Parameters.AddWithValue("@ce", txtce.Text);
                    cmd2.Parameters.AddWithValue("@u", txtu.Text);
                    cmd2.Parameters.AddWithValue("@cl", txtcl.Text);
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

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtc.Text.Trim() != "" && txtn.Text.Trim() != "" && txta.Text.Trim() != "" && txtce.Text.Trim() != "" && txtu.Text.Trim() != "" && txtcl.Text.Trim() != "")
                {

                    Conection.Conectar();
                    string eliminar = "DELETE FROM Administradores WHERE Codigo_administrador=@c";
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

        private void Txtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void Txta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void Administradores_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
