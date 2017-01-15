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
    public partial class CreateUser : Form
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void TxtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                panel1.Visible = true;
            }
            else if (checkBox1.Checked == false)
            {
                panel1.Visible = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Sp_LoginInsert", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", CmbTitle.SelectedItem);
                    cmd.Parameters.AddWithValue("@Name", TxtName.Text);
                    cmd.Parameters.AddWithValue("@Gender", CmbGender.SelectedItem);

                    cmd.Parameters.AddWithValue("@City", CmbCity.SelectedItem);
                    cmd.Parameters.AddWithValue("@UserName", TxtUserName.Text);
                    cmd.Parameters.AddWithValue("@Password", TxtPassword.Text);
                    cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);

                    cmd.Parameters.AddWithValue("@Mobile", TxtMobile.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Inserted Successfully");

                }
                TxtAddress.Text = "";
                TxtMobile.Text = "";
                TxtName.Text = "";
                TxtUserName.Text = "";
                TxtPassword.Text = "";
                TxtPatientId.Text = "";
                CmbCity.Text = "";
                CmbGender.Text = "";
                CmbTitle.Text = "";



            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Login where id=" + TxtPatientId.Text + "", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        CmbTitle.Text = dr["Title"].ToString();
                        TxtName.Text = dr["Name"].ToString();
                        CmbGender.Text = dr["Gender"].ToString();
                        CmbCity.Text = dr["City"].ToString();
                        TxtUserName.Text = dr["Username"].ToString();
                        TxtPassword.Text = dr["Password"].ToString();
                        TxtAddress.Text = dr["Address"].ToString();
                        TxtMobile.Text = dr["Mobile"].ToString();



                    }
                    else
                    {
                        MessageBox.Show("Record not found");
                    }



                }
            }


        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            {
                {
                    String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection cn = new SqlConnection(cs))
                    {

                        cn.Open();
                        SqlCommand cmd = new SqlCommand("Update Login  set Title='" + CmbTitle.Text + "',Name='" + TxtName.Text + "',Gender='" + CmbGender.Text + "',City='" + CmbCity.Text + "',UserName='" + TxtUserName.Text + "',Password='" + TxtPassword.Text + "',Address='" + TxtAddress.Text + "',Mobile='" + TxtMobile.Text + "' where id='" + TxtPatientId.Text + "'", cn);


                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Updated Successfully");

                    }
                    TxtAddress.Text = "";
                    TxtMobile.Text = "";
                    TxtName.Text = "";
                    TxtPatientId.Text = "";
                    CmbCity.Text = "";
                    CmbGender.Text = "";
                    CmbTitle.Text = "";
                    TxtUserName.Text = "";
                    TxtPassword.Text = "";




                }
            }

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            {
                {
                    String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                    using (SqlConnection cn = new SqlConnection(cs))
                    {

                        cn.Open();
                        SqlCommand cmd = new SqlCommand("Delete from Login where id='" + TxtPatientId.Text + "'", cn);


                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully");

                    }
                    TxtAddress.Text = "";
                    TxtMobile.Text = "";
                    TxtName.Text = "";
                    TxtPatientId.Text = "";
                    TxtUserName.Text = "";
                    TxtPassword.Text = "";
                    CmbCity.Text = "";

                    CmbGender.Text = "";
                    CmbTitle.Text = "";



                }
            }

        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            int a;
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    string query = "Select Max(id) from Login";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string val = dr[0].ToString();
                        if (val == "")
                        {
                            textBox1.Text = "1";
                        }
                        else
                        {
                            a = Convert.ToInt32(dr[0].ToString());
                            a = a + 1;
                            textBox1.Text = a.ToString();
                        }
                    }
                }
            }
        }

        
        }

    }
 

