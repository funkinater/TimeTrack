using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Dtos
{
    public class ClockPunchDto
    {
        public int Id { get; set; }
        public EmployeeDto Employee { get; set; }
        public int EmployeeId { get; set; }
        public int PunchTypeId { get; set; }
        public DateTime PunchEventTime { get; set; }

    }
}