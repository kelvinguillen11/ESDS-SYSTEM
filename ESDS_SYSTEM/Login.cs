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

namespace ESDS_SYSTEM
{
    public partial class Login : Form
    {
        private SqlConnection conn;
        private string sCn;
        public Login()
        {
            InitializeComponent();
            datos cn = new datos();
            cn.conec();
            sCn = cn.cadena;
            conn = new SqlConnection(sCn);
        }
        public void login(string user, string pass)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Administradores WHERE Alias_administrador = @usuario AND Clave_administrador = @clave", conn);
                cmd.Parameters.AddWithValue("usuario", user);
                cmd.Parameters.AddWithValue("clave", pass);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count ==1)
                {
                    MessageBox.Show("Bienvenido, administrador", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menu_Admin m = new Menu_Admin();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Usuario o clave incorrectos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            login(this.txtu.Text, this.txtc.Text);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked == true)
            {
                if (txtc.PasswordChar == '*')
                {
                    txtc.PasswordChar = '\0';  
                }
            }
            else
            {
                txtc.PasswordChar = '*';
            }
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Creditos cr = new Creditos();
            cr.Show();
            this.Hide();
        }
    }
}
