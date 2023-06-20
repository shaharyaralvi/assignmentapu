using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Trainer : User
    {
        private string _id;
        private string _name;
        private string _address;
        private string _phone;
        private string _email;
        private string _userId;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; Update(Programming_Café_DB.trainerTable.Name, value); }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; Update(Programming_Café_DB.trainerTable.Address, value); }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; Update(Programming_Café_DB.trainerTable.Phone, value); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; Update(Programming_Café_DB.trainerTable.Email, value); }
        }
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; Update(Programming_Café_DB.trainerTable.UserId, value); }
        }

        public Trainer(User user) : base(user)
        {
            Trainer_Table trainerTable = Programming_Café_DB.trainerTable;
            List<Row> rows = trainerTable.Search_Row_For_Value(trainerTable.UserId, user.Id);
            if (rows.Count == 1)
            {
                _id = rows[0].values[trainerTable.Id];
                _name = rows[0].values[trainerTable.Name];
                _address = rows[0].values[trainerTable.Address];
                _phone = rows[0].values[trainerTable.Phone];
                _email = rows[0].values[trainerTable.Email];

            }

        }

        public void Update(Column collumnAffected, string value)
        {
            Row rowToBeChanged = Programming_Café_DB.trainerTable.Rows.Find(row => row.values[Programming_Café_DB.trainerTable.Id] == _id);
            for (int i = 0; i < Programming_Café_DB.trainerTable.Rows.Count; i++)
            {
                if (Programming_Café_DB.trainerTable.Rows[i] == rowToBeChanged)
                {
                    // Update the dictionary using the property's setter
                    Dictionary<Column, string> updatedValues = Programming_Café_DB.trainerTable.Rows[i].values;
                    updatedValues[collumnAffected] = value;
                    Programming_Café_DB.trainerTable.Rows[i].values = updatedValues;
                }
            }
        }


    }
}
