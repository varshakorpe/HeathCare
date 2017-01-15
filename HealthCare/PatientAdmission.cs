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
    public partial class PatientAdmission : Form
    {
        public PatientAdmission()
        {
            InitializeComponent();
        }

        private void CmbTitle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbBlood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from PatientReg where Name='" + comboBox1.Text + "'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        TxtID.Text = dr["id"].ToString();
                        TxtTitle.Text = dr["Title"].ToString();
                        TxtCity.Text = dr["City"].ToString();
                        TxtAddress.Text = dr["Address"].ToString();
                        TxtMobile.Text = dr["Mobile"].ToString();
                        TxtGender.Text = dr["Gender"].ToString();
                        TxtBlood.Text = dr["Blood"].ToString();
                        TxtProblem.Text = dr["Problem"].ToString();
                        TxtDoctor.Text = dr["DoctorName"].ToString();



                    }




                        }
                    }


                }

        private void PatientAdmission_Load(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select Name from PatientReg ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["Name"].ToString());
                    }




                }
            }
        }

        private void TxtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtBlood_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtGender_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDoctor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Sp_PatientAdmissionInsert", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", TxtTitle.Text);
                    cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Gender", TxtGender.Text);
                    cmd.Parameters.AddWithValue("@City", TxtCity.Text);
                    cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
                    cmd.Parameters.AddWithValue("@Mobile", TxtMobile.Text);
                    cmd.Parameters.AddWithValue("@Blood", TxtBlood.Text);
                    cmd.Parameters.AddWithValue("@Problem", TxtProblem.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", TxtDoctor.Text);
                    cmd.Parameters.AddWithValue("@RoomType", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@RoomNo", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@BedNo", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@CurrentDate", Convert.ToDateTime(dateTimePicker1.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record Inserted Successfully");

                }
                TxtAddress.Text = "";
                TxtMobile.Text = "";
                TxtDoctor.Text = "";
                TxtCity.Text = "";
                TxtBlood.Text = "";
                TxtGender.Text = "";
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                TxtID.Text = "";
                TxtTitle.Text = "";



            }
        }

        private void TxtProblem_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
