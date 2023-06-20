using APU_Programming_Café_Management_System.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System.Users
{
    public class Lecturer : User
    {
        private string _id;
        private string _name;
        private string _address;
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
            set { _name = value; Update(Programming_Café_DB.lecturerTable.Name, value); }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; Update(Programming_Café_DB.lecturerTable.Address, value); }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; Update(Programming_Café_DB.lecturerTable.Phone, value); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; Update(Programming_Café_DB.lecturerTable.Email, value); }
        }
        public string UserId
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        public Lecturer(User user) : base(user)
        {
            Lecturer_Table lecturerTable = Programming_Café_DB.lecturerTable;
            List<Row> rows = lecturerTable.Search_Row_For_Value(lecturerTable.UserId, user.Id);
            if (rows.Count == 1)
            {
                _id = rows[0].values[lecturerTable.Id];
                _name = rows[0].values[lecturerTable.Name];
                _address = rows[0].values[lecturerTable.Address];
                _phone = rows[0].values[lecturerTable.Phone];
                _email = rows[0].values[lecturerTable.Email];

            }

        }

        public void Update(Column collumnAffected, string value)
        {
            Row rowToBeChanged = Programming_Café_DB.lecturerTable.Rows.Find(row => row.values[Programming_Café_DB.lecturerTable.Id] == _id);
            for (int i = 0; i < Programming_Café_DB.lecturerTable.Rows.Count; i++)
            {
                if (Programming_Café_DB.lecturerTable.Rows[i] == rowToBeChanged)
                {
                    // Update the dictionary using the property's setter
                    Dictionary<Column, string> updatedValues = Programming_Café_DB.lecturerTable.Rows[i].values;
                    updatedValues[collumnAffected] = value;
                    Programming_Café_DB.lecturerTable.Rows[i].values = updatedValues;
                }
            }
        }
    }
}
