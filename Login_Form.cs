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
using APU_Programming_Café_Management_System.TrainerForm;
using APU_Programming_Café_Management_System.LecturerForm;
using APU_Programming_Café_Management_System.StudentForm;

namespace APU_Programming_Café_Management_System
{
    public partial class Login_Form : Form
    {
        Programming_Café_DB Programming_Café_Database;
        public Login_Form()
        {
            InitializeComponent();
            Programming_Café_Database = new Programming_Café_DB();
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            User user = new User(txtbox_Username.Text, txtbox_Password.Text);
            if(user.login == true)
            {
                if(user.role.isAdministrator == true)
                {
                    this.Hide();
                    AdminUI adminUI = new AdminUI(user);
                    adminUI.ShowDialog();
                    this.Close();
                }
                else if(user.role.isTrainer == true)
                {
                    this.Hide();
                    TrainerUI trainerUI = new TrainerUI(user);
                    trainerUI.ShowDialog();
                    this.Close();
                }
                else if(user.role.isLecturer == true)
                {
                    this.Hide();
                    LecturerUI lecturerUI = new LecturerUI(user);
                    lecturerUI.ShowDialog();
                    this.Close();
                }
                else if(user.role.isStudent == true)
                {
                    this.Hide();
                    StudentUI studentUI = new StudentUI(user);
                    studentUI.ShowDialog();
                    this.Close();
                }
            }
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            //test
        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
