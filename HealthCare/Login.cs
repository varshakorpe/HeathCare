using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace HealthCare
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select UserName from Login ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CmbUserName.Items.Add(dr["Username"].ToString());
                    }




                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Login where Username='" + CmbUserName.Text + "'and Password='" + textBox2.Text + "' ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        Menu obj = new Menu();
                        obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed");
                    }


                }
            }
        }

        private void CmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

