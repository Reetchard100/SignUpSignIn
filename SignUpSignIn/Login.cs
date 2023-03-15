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

namespace SignUpSignIn
{
    public partial class Login : Form
    {
        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader dr; 
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != string.Empty || txtUsername.Text != string.Empty)
            {

                cmd = new OleDbCommand("select * from users where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    BtnUser = txtUsername.Text;
                    dr.Close();
                    this.Hide();
                    Menu home = new Menu();
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\NH-EXT\\Desktop\\SignUpAndSignIn\\SignUpAndSignIn\\SignUpAndSignIn.mdb");
            con.Open();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration register = new Registration();
            register.ShowDialog();
        }
    }
}
