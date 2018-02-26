using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class FlagEventComment
    {
        public int Id { get; set; }
        public ScheduleFlag ScheduleFlag { get; set; }
        public int ScheduleFlagId { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
    }
}