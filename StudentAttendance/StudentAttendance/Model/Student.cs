using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAttendance.Model
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int SID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsSignedUp { get; set; }
    }
}
