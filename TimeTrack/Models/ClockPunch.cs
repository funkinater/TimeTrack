using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class ClockPunch
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public PunchType PunchType { get; set; }
        public int PunchTypeId { get; set; }
        public DateTime PunchEventTime { get; set; }
    }
}