using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Administrator : User
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
            set { _name = value; Update(Programming_Café_DB.administratorTable.Name, value); }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; Update(Programming_Café_DB.administratorTable.Address, value); }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; Update(Programming_Café_DB.administratorTable.Phone, value); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; Update(Programming_Café_DB.administratorTable.Email, value); }
        }
        public string UserId
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        public Administrator(User user) : base(user)
        {
            Administrator_Table adminTable = Programming_Café_DB.administratorTable;
            List<Row> rows = adminTable.Search_Row_For_Value(adminTable.UserId, user.Id);
            if (rows.Count == 1)
            {
                _id = rows[0].values[adminTable.Id];
                _name = rows[0].values[adminTable.Name];
                _address = rows[0].values[adminTable.Address];
                _phone = rows[0].values[adminTable.Phone];
                _email = rows[0].values[adminTable.Email];
                
            }

        }

        public void Update(Column collumnAffected, string value)
        {
            Row rowToBeChanged = Programming_Café_DB.administratorTable.Rows.Find(row => row.values[Programming_Café_DB.administratorTable.Id] == _id);
            for(int i = 0; i < Programming_Café_DB.administratorTable.Rows.Count; i++)
            {
                if (Programming_Café_DB.administratorTable.Rows[i] == rowToBeChanged)
                {
                    // Update the dictionary using the property's setter
                    Dictionary<Column, string> updatedValues = Programming_Café_DB.administratorTable.Rows[i].values;
                    updatedValues[collumnAffected] = value;
                    Programming_Café_DB.administratorTable.Rows[i].values = updatedValues;
                }
            }
        }


    }
}
