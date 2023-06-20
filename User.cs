using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System
{
    public class User
    {
        private string _id;
        private string _username; 
        private string _password;
        private Role _role;
        private bool _login;

        public User(string Username, string Password) 
        {
            _username = Username;
            _password = Password;
            _role = new Role();
            _login = login_Attempt();
        }

        public User (User user)
        {
            _id = user.Id;
            _username = user.Username;
            _password = user.Password;
            _role = new Role();
            _login = login_Attempt();
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Username
        {
            get{ return _username; }
            set { _username = value; Update(Programming_Café_DB.userTable.Username, value); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; Update(Programming_Café_DB.userTable.Password, value); }
        }
        public Role role
        { 
            get { return _role; }
            set { _role = value; }
        }

        public bool login
        {
            get { return _login; }
            set { _login = value; }
        }
   

        public bool login_Attempt()
        {
            List<Row> rows = Programming_Café_DB.userTable.Search_Row_For_Username_Value(_username);
            if (rows.Count == 1)
            {
                if (rows[0].values[Programming_Café_DB.userTable.Password] == _password)
                {
                    
                    _id = rows[0].values[Programming_Café_DB.userTable.Id];
                    Check_User_Role();
                    return true;
                }

                else { MessageBox.Show("Password is Wrong"); }
            }
            else
            {
                MessageBox.Show("Username doesn't exist");
            }
            return false;
        }

        public void Check_User_Role()
        {
            

            if (Programming_Café_DB.administratorTable.Search_Row_For_Value("UserId", _id).Count == 1)
            {
                _role.isAdministrator = true;
            }
            else if (Programming_Café_DB.trainerTable.Search_Row_For_Value("UserId", _id).Count == 1)
            {
                _role.isTrainer= true;
            }
            else if (Programming_Café_DB.lecturerTable.Search_Row_For_Value("UserId", _id).Count == 1)
            {
                _role.isLecturer = true;
            }
            else if (Programming_Café_DB.studentTable.Search_Row_For_Value("UserId", _id).Count == 1)
            {
                _role.isStudent = true;
            }

        }

        public void Update(Column collumnAffected, string value)
        {
            Row rowToBeChanged = Programming_Café_DB.userTable.Rows.Find(row => row.values[Programming_Café_DB.userTable.Id] == _id);
            for (int i = 0; i < Programming_Café_DB.userTable.Rows.Count; i++)
            {
                if (Programming_Café_DB.userTable.Rows[i] == rowToBeChanged)
                {
                    // Update the dictionary using the property's setter
                    Dictionary<Column, string> updatedValues = Programming_Café_DB.userTable.Rows[i].values;
                    updatedValues[collumnAffected] = value;
                    Programming_Café_DB.userTable.Rows[i].values = updatedValues;
                }
            }
        }
    }
}
