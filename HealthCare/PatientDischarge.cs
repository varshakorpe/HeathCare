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
    public partial class PatientDischarge : Form
    {
        public PatientDischarge()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Sp_PatientDischarge", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", TxtTitle.Text);
                    cmd.Parameters.AddWithValue("@Name", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@Gender", TxtGender.Text);
                    cmd.Parameters.AddWithValue("@City", TxtCity.Text);
                    cmd.Parameters.AddWithValue("@CurrentDate", Convert.ToDateTime(TxtAdmissionDate.Text));
                    cmd.Parameters.AddWithValue("@Address", TxtAddress.Text);
                    cmd.Parameters.AddWithValue("@Mobile", TxtMobile.Text);
                    cmd.Parameters.AddWithValue("@Blood", TxtBlood.Text);
                    cmd.Parameters.AddWithValue("@Problem", TxtProblem.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", TxtDoctor.Text);
                    cmd.Parameters.AddWithValue("@RoomType", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@RoomNo", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@BedNo", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@DischargeDate", Convert.ToDateTime(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@CheckUpFee", TxtCheckUp.Text);
                    cmd.Parameters.AddWithValue("@Maintainance", TxtMaintainance.Text);
                    cmd.Parameters.AddWithValue("@BedCharges", TxtBedCharges.Text);
                    cmd.Parameters.AddWithValue("@Total",TxtTotal.Text);
                    cmd.Parameters.AddWithValue("@Remark", TxtRemark.Text);

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
                TxtAdmissionDate.Text = "";
                TxtBedCharges.Text = "";
                TxtCheckUp.Text = "";
                TxtMaintainance.Text = "";
                TxtRemark.Text = "";
                TxtTotal.Text = "";



            }
        }

        private void CmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {

                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select * from PatientAdmission where Name='" + comboBox1.Text + "'", cn);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        TxtID.Text = dr["id"].ToString();
                        TxtTitle.Text = dr["Title"].ToString();
                        TxtCity.Text = dr["City"].ToString();
                        TxtAdmissionDate.Text = dr["CurrentDate"].ToString();
                        TxtAddress.Text = dr["Address"].ToString();
                        TxtMobile.Text = dr["Mobile"].ToString();
                        TxtGender.Text = dr["Gender"].ToString();
                        TxtBlood.Text = dr["Blood"].ToString();
                        TxtProblem.Text = dr["Problem"].ToString();
                        TxtDoctor.Text = dr["DoctorName"].ToString();
                        comboBox2.Text = dr["Roomtype"].ToString();
                        comboBox3.Text = dr["RoomNo"].ToString();
                        comboBox4.Text = dr["BedNo"].ToString();



                    }




                }
            }


        }

        private void PatientDischarge_Load(object sender, EventArgs e)
        {
            {
                String cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(cs))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("Select Name from PatientAdmission ", cn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr["Name"].ToString());
                    }

                }
            }
        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {
            //TxtTotal.Text =(Convert.ToDouble(TxtMaintainance.Text) + Convert.ToDouble( TxtBedCharges.Text) +Convert.ToDouble( TxtCheckUp.Text)).ToString();
           // TxtTotal.Text = Convert.ToString(Convert.ToInt32(TxtMaintainance.Text) + Convert.ToInt32(TxtBedCharges.Text));
        }

        private void TxtMaintainance_TextChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(TxtMaintainance.Text) && !string.IsNullOrEmpty(TxtCheckUp.Text)&&!string.IsNullOrEmpty(TxtBedCharges.Text))
                TxtTotal.Text = (Convert.ToInt32(TxtMaintainance.Text) + Convert.ToInt32(TxtCheckUp.Text)+Convert.ToInt32(TxtBedCharges.Text)).ToString();
        
    }

        private void TxtCheckUp_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtMaintainance.Text) && !string.IsNullOrEmpty(TxtCheckUp.Text) && !string.IsNullOrEmpty(TxtBedCharges.Text))
                TxtTotal.Text = (Convert.ToInt32(TxtMaintainance.Text) + Convert.ToInt32(TxtCheckUp.Text) + Convert.ToInt32(TxtBedCharges.Text)).ToString();

        }

        private void TxtBedCharges_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtMaintainance.Text) && !string.IsNullOrEmpty(TxtCheckUp.Text) && !string.IsNullOrEmpty(TxtBedCharges.Text))
                TxtTotal.Text = (Convert.ToInt32(TxtMaintainance.Text) + Convert.ToInt32(TxtCheckUp.Text) + Convert.ToInt32(TxtBedCharges.Text)).ToString();

        }
    }
}
