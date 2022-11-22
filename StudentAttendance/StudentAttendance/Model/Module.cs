using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAttendance.Model
{
    public class Module
    {
        [PrimaryKey, AutoIncrement]
        public int MID { get; set; }
        public string Title { get; set; }
        public string MCode { get; set; }
        public int CreditUnits { get; set; }
        public int TutorID { get; set; }


    }
}
