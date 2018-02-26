using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class ScheduleFlag
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public ScheduleFlagType ScheduleFlagType { get; set; }
        public int ScheduleFlagTypeId { get; set; }
        public FlagDispositionType FlagDispositionType { get; set; }
        public int FlagDispositionTypeId { get; set; }
    }
}