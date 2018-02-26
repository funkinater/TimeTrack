using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class EmployeeHoursRecord
    {
        public int Id { get; set; }
        public PayPeriod PayPeriod { get; set; }
        public int PayPeriodId { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public double TotalHoursWorked { get; set; }
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
    }
}