using APU_Programming_Café_Management_System.LecturerForm;
using APU_Programming_Café_Management_System.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System.StudentForm
{
    public partial class StudentProfile : UserControl
    {
        Student student;
        public StudentProfile(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void StudentProfile_Load(object sender, EventArgs e)
        {
            txtBoxUsername.Text = student.Username;
            txtBoxPassword.Text = student.Password;
            txtBoxName.Text = student.Name;
            txtBoxTPNumber.Text = student.TP_Number;
            txtBoxAddress.Text = student.Address;
            txtBoxPhone.Text = student.Phone;
            txtBoxEmail.Text = student.Email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Column columnToSearch = Programming_Café_DB.userTable.Username;
                int count = Programming_Café_DB.userTable.Search_Row_For_Value(columnToSearch, txtBoxUsername.Text).Count;
                if (count == 0 || student.Username == txtBoxUsername.Text)
                {
                    student.Username = txtBoxUsername.Text;
                    student.Password = txtBoxPassword.Text;
                    student.Name = txtBoxName.Text;
                    student.Address = txtBoxAddress.Text;
                    student.Phone = txtBoxPhone.Text;
                    student.Email = txtBoxEmail.Text;
                    MessageBox.Show("Saved");
                }
                else
                {
                    MessageBox.Show("Username Already Exists");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Save Failed");
            }
        }
    }
}
