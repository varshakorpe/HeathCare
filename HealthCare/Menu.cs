using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            {
                obj.Show();
                //this.Hide();
                obj.Focus();
            }
        }

        private void newAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientAdmission obj = new PatientAdmission();
            {
                obj.Show();
                obj.Focus();
            }
        }

        private void dischargePatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientDischarge obj = new PatientDischarge();
            {
                obj.Show();
                obj.Focus();
            }
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser obj = new CreateUser();
            obj.Show();
            obj.Focus();
        }
    }
}
