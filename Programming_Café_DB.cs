using APU_Programming_Café_Management_System.Tables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace APU_Programming_Café_Management_System
{
    public class Programming_Café_DB
    {
        //Fields
        public static string connectionString;
        private DataSet _dataset;
        SqlConnection connection;
        private static Administrator_Table _administratorTable;
        private static Trainer_Table _trainerTable;
        private static Student_Table _studentTable;
        private static User_Table _userTable;
        private static Class_Table _classTable;
        private static Module_Table _moduleTable;
        private static Feedback_Table _feedbackTable;
        private static StudentModule_Table _studentModule_Table;
        private static Lecturer_Table _lecturer_Table;
        private static Request_Table _request_Table;
       
        //Constructor
        public Programming_Café_DB()
        {
            connectionString = ConfigurationManager.ConnectionStrings["APU_Programming_Café_Management_System_DB"].ConnectionString;
            _dataset = dataSet;
            _studentTable = new Student_Table(dataSet.Tables["Students"]);
            userTable = new User_Table(_dataset.Tables["Users"]);
            _administratorTable = new Administrator_Table(_dataset.Tables["Administrators"]);
            _trainerTable = new Trainer_Table(_dataset.Tables["Trainers"]);
            _classTable = new Class_Table(_dataset.Tables["Classes"]);
            _moduleTable = new Module_Table(_dataset.Tables["Modules"]);
            _feedbackTable = new Feedback_Table(_dataset.Tables["Feedbacks"]);
            _studentModule_Table = new StudentModule_Table(_dataset.Tables["StudentModules"]);
            _lecturer_Table = new Lecturer_Table(_dataset.Tables["Lecturers"]);
            _request_Table = new Request_Table(_dataset.Tables["Requests"]);
        }

        //Property
        public DataSet dataSet
        {
            get
            {
                List<string> tableNames = Get_Table_List();
                DataSet ds = new DataSet();
                int i = 0;
                foreach (string tableName in tableNames)
                {
                    ds.Tables.Add(Get_DataTable_From_Table(tableName));
                    ds.Tables[i].TableName = tableName;
                    i++;
                }
                

                return ds;
            }
        }


        public static Student_Table studentTable
        {
            get { return _studentTable; }
            set { _studentTable = value; }
        }

        public static User_Table userTable
        {
            get { return _userTable; }
            set { _userTable = value; }
        }

        public static Administrator_Table administratorTable
        {
            get { return _administratorTable; }
            set { _administratorTable = value; }
        }

        public static Trainer_Table trainerTable
        {
            get { return _trainerTable; }
            set { _trainerTable = value; }
        }

        public static Class_Table classTable
        {
            get { return _classTable; }
            set { _classTable = value; }
        }

        public static Module_Table moduleTable
        {
            get { return _moduleTable; }
            set { _moduleTable = value; }
        }

        public static Feedback_Table feedbackTable
        {
            get { return _feedbackTable; }
            set { _feedbackTable = value; }
        }

        public static StudentModule_Table studentModuleTable
        {
            get { return _studentModule_Table; }
            set { _studentModule_Table = value; }
        }

        public static Lecturer_Table lecturerTable
        {
            get { return _lecturer_Table; }
            set { _lecturer_Table = value; }
        }

        public static Request_Table requestTable
        {
            get { return _request_Table; }
            set { _request_Table = value; }
        }

        //Methods

        //returns a list of strings that contains all the table names inside the database
        public List<string> Get_Table_List()
        {
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }

        //a that takes a parameter of a tablename and then returns a DataTable from the database
        public static DataTable Get_DataTable_From_Table(string table)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter("select * from " + table, connection))
            {
                connection.Open();
                DataTable dt = new DataTable();
                da.Fill(dt);
                dt.TableName = table;
                return (dt);
            }

        }

        public static void Update_Table_Database(string tableName, Row rowToBeUpdated, Dictionary<Column, string> values)
        {
            
            string commandString = "UPDATE " + tableName + " SET ";
            Column key = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            bool primaryKey = false;
            foreach (KeyValuePair<Column, string> kvp in values)
            {
                if (!kvp.Key.IsPKey)
                {
                    commandString += kvp.Key.Name + " = @" + kvp.Key.Name + ", ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);
                }
                else if (key == null)
                {
                    key = kvp.Key;
                    primaryKey = true;
                }
            }
            commandString = commandString.TrimEnd(',', ' ');
            // Add WHERE clause
            commandString += " WHERE ";
            //If primary key exists
            if (primaryKey)
            {

                // Add WHERE clause
                commandString += key.Name + " = @" + key.Name;

                // Add parameter for the primary key value
                SqlParameter primaryKeyParameter = new SqlParameter("@" + key.Name, rowToBeUpdated.values[key]);
                parameters.Add(primaryKeyParameter);
            }
            else
            {
                foreach (KeyValuePair<Column, string> kvp in rowToBeUpdated.values)
                {

                    commandString += kvp.Key.Name + " = @n" + kvp.Key.Name + " AND ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@n" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);

                }

                // Remove trailing "AND"
                commandString = commandString.Remove(commandString.Length - 5);
            }


            // Execute the query
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandString, connection))
            {
                cmd.Parameters.AddRange(parameters.ToArray());
                connection.Open();
                cmd.ExecuteScalar();
            }

        }

        public static void Insert_Row_Database(Table table, Row rowToBeInserted, List<Column> uniqueColumns)
        {
            // Check if the row already exists
            bool rowExists = Check_Row_Exists(table, rowToBeInserted, uniqueColumns);
            if (rowExists == false)
            {
                string commandString = "INSERT INTO " + table.TableName + " (";
                string valueString = "VALUES (";
                List<SqlParameter> parameters = new List<SqlParameter>();

                foreach (KeyValuePair<Column, string> kvp in rowToBeInserted.values)
                {
                    if (kvp.Key.IsPKey == false)
                    {
                        commandString += kvp.Key.Name + ", ";
                        valueString += "@" + kvp.Key.Name + ", ";

                        // Add parameter for the value
                        SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                        parameters.Add(parameter);
                    }
                }

                // Remove trailing comma and space
                commandString = commandString.TrimEnd(',', ' ');
                valueString = valueString.TrimEnd(',', ' ');

                // Complete the command and combine the strings
                commandString += ") " + valueString + ")";

                // Execute the query
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(commandString, connection))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    cmd.ExecuteScalar();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Row already exists.");
            }
        }

        public static void Delete_Row_Database(Table table, Row rowToBeDeleted)
        {
            bool primaryKey = false;
            foreach(Column column in table.Columns)
            {
                //If there is primary key in the columns
                if(column.IsPKey)
                {
                    Column primaryKeyColumn = column;
                    string primaryKeyColumnName = column.Name;
                    string primaryKeyValue = rowToBeDeleted.values[primaryKeyColumn];

                    string commandString = "DELETE FROM " + table.TableName + " WHERE " + primaryKeyColumnName + " = @" + primaryKeyColumnName;
                    SqlParameter parameter = new SqlParameter("@" + primaryKeyColumnName, primaryKeyValue);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(commandString, connection))
                    {
                        cmd.Parameters.Add(parameter);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    primaryKey= true;
                    break;
                }  
            }
            if(primaryKey == false)
            {
                string commandString = "DELETE FROM " + table.TableName + " WHERE ";
                List<SqlParameter> parameters = new List<SqlParameter>();

                foreach (KeyValuePair<Column, string> kvp in rowToBeDeleted.values)
                {

                        commandString += kvp.Key.Name + " = @" + kvp.Key.Name + " AND ";

                        // Add parameter for the value
                        SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                        parameters.Add(parameter);

                }
                if (parameters.Count > 0)
                {
                    // Remove trailing "AND"
                    commandString = commandString.Remove(commandString.Length - 5);

                    // Execute the query
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(commandString, connection))
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                        connection.Open();
                        cmd.ExecuteScalar();
                    }
                }
                else
                {
                    MessageBox.Show("Delete failed");
                }
            }
            


        }

        public static bool Check_Row_Exists(Table table, Row row, List<Column> uniqueColumns)
        {
            string commandString = "SELECT COUNT(*) FROM " + table.TableName + " WHERE ";
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach (KeyValuePair<Column, string> kvp in row.values)
            {
                if (kvp.Key.Name == "Username" || kvp.Key.Name == "UserId")
                {
                    if (Get_DataRows_From_DataTable(Get_DataTable_From_Table(table.TableName), kvp.Key.Name, kvp.Value).Length > 0)

                    //if (table.Search_Row_For_Value(kvp.Key, kvp.Value).Count > 0)
                    {
                        return true;
                    }
                }
                
                if(uniqueColumns.Contains(kvp.Key))
                {
                    commandString += kvp.Key.Name + " = @" + kvp.Key.Name + " AND ";

                    // Add parameter for the value
                    SqlParameter parameter = new SqlParameter("@" + kvp.Key.Name, kvp.Value);
                    parameters.Add(parameter);
                }
                
            }
            if(parameters.Count > 0)
            {
                // Remove trailing "AND"
                commandString = commandString.Remove(commandString.Length - 5);

                // Execute the query
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(commandString, connection))
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            return false;
           
        }
        

        public static DataRow[] Get_DataRows_From_DataTable(DataTable dt, string columnName, string value)
        {
            DataRow[] filteredRows = dt.Select(columnName + " = '" + value + "'");
            return filteredRows;
        }

        public static DataRow[] Get_DataRows_From_DataTable(DataTable dt, string columnName, int value)
        {
            string str_value = value.ToString();
            DataRow[] filteredRows = dt.Select(columnName + " = " + value);
            return filteredRows;
        }

    }
}