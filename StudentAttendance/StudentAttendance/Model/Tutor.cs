using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAttendance.Model
{
    public class Tutor
    {
        [PrimaryKey, AutoIncrement]
        public int TID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }       
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSignedUp { get; set; }
    }
}
