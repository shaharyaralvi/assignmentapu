using APU_Programming_Café_Management_System.Tables;
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
    public partial class StudentRequestsAdd : UserControl
    {
        Student student;
        StudentRequests studentRequests;
        public StudentRequestsAdd(Student student, StudentRequests studentRequests)
        {
            InitializeComponent();
            this.student = student;
            this.studentRequests = studentRequests;

            foreach (Row row in Programming_Café_DB.moduleTable.Rows)
            {
                cmbBoxModule.Items.Add(row.values[Programming_Café_DB.moduleTable.Name]);
            }
            cmbBoxLevel.Items.Add("Beginner");
            cmbBoxLevel.Items.Add("Intermediate");
            cmbBoxLevel.Items.Add("Advance");
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            Column columnToSearch = Programming_Café_DB.moduleTable.Name;
            Column columnToReturn = Programming_Café_DB.moduleTable.Id;
            string moduleId = Programming_Café_DB.moduleTable.Get_ColumnValue_From_Row(columnToSearch, cmbBoxModule.Text, columnToReturn);
            List<string> requestValues = new List<string>
            {
                //first value is empty because its a primary key
                "",
                student.Id,
                moduleId,
                cmbBoxLevel.Text,
            };


            if (Check_If_Empty(requestValues))
            {
                MessageBox.Show("User section contains empty values");
            }
            else
            {
                bool ModulesAndLevelExists = false;
                columnToSearch = Programming_Café_DB.studentModuleTable.StudentId;
                List<Row> rows = Programming_Café_DB.studentModuleTable.Search_Row_For_Value(columnToSearch, student.Id);
                foreach(Row row in rows)
                {
                    if (row.values[Programming_Café_DB.studentModuleTable.ModuleId] == moduleId && row.values[Programming_Café_DB.studentModuleTable.Level] == cmbBoxLevel.Text)
                    {
                        ModulesAndLevelExists = true;
                        MessageBox.Show("Student is already enrolled into this module and level");
                    }
                }
                if(!ModulesAndLevelExists)
                {
                    List<Column> uniqueColumns = new List<Column>()
                    {
                        Programming_Café_DB.requestTable.StudentId,
                        Programming_Café_DB.requestTable.ModuleId,
                        Programming_Café_DB.requestTable.Level
                    };
                    Programming_Café_DB.requestTable.Insert_Row(requestValues, uniqueColumns);
                    studentRequests.Load_List_View();
                    this.Dispose();
                }

            }
        }
        private bool Check_If_Empty(List<string> value)
        {
            bool is_Empty = false;
            //starts at 1 because the first value is always empty
            for (int i = 1; i < value.Count; i++)
            {
                if (value[i] == null || value[i] == "")
                {
                    is_Empty = true;
                }
            }
            return is_Empty;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void StudentRequestsAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
