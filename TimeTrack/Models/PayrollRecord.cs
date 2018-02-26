using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class PayrollRecord
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public int PayPeriodId { get; set; }
        public double TotalHoursWorked { get; set; }

    }
}