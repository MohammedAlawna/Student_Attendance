using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAttendance.Model
{
    public class Session : Module
    {
        [PrimaryKey, AutoIncrement]
        public int SessionId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int ModuleID { get; set; }

    }
}
