using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APU_Programming_Café_Management_System
{
    public class Role
    {
        private bool _isAdministrator;
        private bool _isTrainer;
        private bool _isLecturer;
        private bool _isStudent;


        public bool isAdministrator 
        {
            get { return _isAdministrator; } 
            set { _isAdministrator = value; }
        }
        public bool isTrainer 
        {
            get { return _isTrainer; }
            set { _isTrainer = value; }
        }
        public bool isLecturer 
        {
            get { return _isLecturer;}
            set { _isLecturer = value;}
        }
        public bool isStudent 
        {
            get { return _isStudent;}
            set { _isStudent = value;}
        }

        public Role() 
        {
            _isAdministrator= false;
            _isLecturer= false;
            _isTrainer= false;
            _isStudent= false;
        }
    }
}
