using System;

namespace HelloWorld.Models.Data.Entity
{
    public class Attendance
    {
        public int  Id { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}