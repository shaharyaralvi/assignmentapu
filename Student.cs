using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Users
{
    public class Student : User
    {
        private string _id;
        private string _name;
        private string _address;
        private string _TP_Number;
        private string _phone;
        private string _email;

        public new string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; Update(Programming_Café_DB.studentTable.Name, value); }
        }
        public string TP_Number
        {
            get { return _TP_Number; }
            set { _TP_Number = value;}
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; Update(Programming_Café_DB.studentTable.Address, value); }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; Update(Programming_Café_DB.studentTable.Phone, value); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; Update(Programming_Café_DB.studentTable.Email, value); }
        }
        public string UserId
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        public Student(User user) : base(user)
        {
            Student_Table studentTable = Programming_Café_DB.studentTable;
            List<Row> rows = studentTable.Search_Row_For_Value(studentTable.UserId, user.Id);
            if (rows.Count == 1)
            {
                _id = rows[0].values[studentTable.Id];
                _name = rows[0].values[studentTable.Name];
                _TP_Number = rows[0].values[studentTable.TP_Number];
                _address = rows[0].values[studentTable.Address];
                _phone = rows[0].values[studentTable.Phone];
                _email = rows[0].values[studentTable.Email];

            }

        }

        public void Update(Column collumnAffected, string value)
        {
            Row rowToBeChanged = Programming_Café_DB.studentTable.Rows.Find(row => row.values[Programming_Café_DB.studentTable.Id] == _id);
            for (int i = 0; i < Programming_Café_DB.studentTable.Rows.Count; i++)
            {
                if (Programming_Café_DB.studentTable.Rows[i] == rowToBeChanged)
                {
                    // Update the dictionary using the property's setter
                    Dictionary<Column, string> updatedValues = Programming_Café_DB.studentTable.Rows[i].values;
                    updatedValues[collumnAffected] = value;
                    Programming_Café_DB.studentTable.Rows[i].values = updatedValues;
                }
            }
        }
    }
}
