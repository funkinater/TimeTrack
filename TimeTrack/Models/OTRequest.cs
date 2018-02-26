using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class OtRequest
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public DateTime TargetOtDate { get; set; }
        public double NumberHoursRequested { get; set; }
        public string ClientMatter { get; set; }
        public bool AttorneyRequested { get; set; }
        public bool SupervisorApproved { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ApprovalComment { get; set; }

    }
}