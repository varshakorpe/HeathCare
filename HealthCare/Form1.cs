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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int a;
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    string query = "Select Max(id) from PatientReg";
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

        private void button1_Click(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Sp_PatientInsert", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", CmbTitle.SelectedItem);
                    cmd.Parameters.AddWithValue("@Name", TxtName.Text);
                    cmd.Parameters.AddWithValue("@City", CmbCity.SelectedItem);
                    cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);

                    cmd.Parameters.AddWithValue("@Mobile", TxtMobile.Text);
                    cmd.Parameters.AddWithValue("@Gender", CmbGender.SelectedItem);
                    cmd.Parameters.AddWithValue("@Blood", CmbBlood.SelectedItem);
                    cmd.Parameters.AddWithValue("@Problem", TxtProblem.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", CmbDoctorName.SelectedItem);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Inserted Successfully");

                }
                TxtAddress.Text = "";
                TxtMobile.Text = "";
                TxtName.Text = "";
                TxtPatientId.Text = "";
                TxtProblem.Text = "";
                CmbBlood.Text = "";
                CmbCity.Text = "";
                CmbDoctorName.Text = "";
                CmbGender.Text = "";
                CmbTitle.Text = "";



            }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from PatientReg where id="+TxtPatientId.Text+"", cn);
                    //SqlCommand cmd = new SqlCommand("Sp_PatientSearch", cn);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.Add("@id", SqlDbType.Int);

                    //cmd.Parameters["@id"].Value = TxtPatientId.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        CmbTitle.Text = dr["Title"].ToString();
                        TxtName.Text = dr["Name"].ToString();
                        CmbCity.Text = dr["City"].ToString();
                        TxtAddress.Text = dr["Address"].ToString();
                        TxtMobile.Text = dr["Mobile"].ToString();
                        CmbGender.Text = dr["Gender"].ToString();
                        CmbBlood.Text = dr["Blood"].ToString();
                        TxtProblem.Text = dr["Problem"].ToString();
                        CmbDoctorName.Text = dr["DoctorName"].ToString();

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
                        SqlCommand cmd = new SqlCommand("Update PatientReg  set Title='" + CmbTitle.Text + "',Name='" + TxtName.Text + "',City='" + CmbCity.Text + "',Address='" + TxtAddress.Text + "',Mobile='" + TxtMobile.Text + "',Gender='" + CmbGender.Text + "',Blood='" + CmbBlood.Text + "',Problem='"+TxtProblem.Text+ "',DoctorName='"+CmbDoctorName.Text+ "' where id='" + TxtPatientId.Text + "'", cn);
                       

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Updated Successfully");

                    }
                    TxtAddress.Text = "";
                    TxtMobile.Text = "";
                    TxtName.Text = "";
                    TxtPatientId.Text = "";
                    TxtProblem.Text = "";
                    CmbBlood.Text = "";
                    CmbCity.Text = "";
                    CmbDoctorName.Text = "";
                    CmbGender.Text = "";
                    CmbTitle.Text = "";



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
                        SqlCommand cmd = new SqlCommand("Delete from PatientReg where id='"+TxtPatientId.Text+"'", cn);


                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Record Deleted Successfully");

                    }
                    TxtAddress.Text = "";
                    TxtMobile.Text = "";
                    TxtName.Text = "";
                    TxtPatientId.Text = "";
                    TxtProblem.Text = "";
                    CmbBlood.Text = "";
                    CmbCity.Text = "";
                    CmbDoctorName.Text = "";
                    CmbGender.Text = "";
                    CmbTitle.Text = "";



                }
            }

        }
    }
}
            

        
    
