using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class HolidayShortDay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double HoursCredited { get; set; }
    }
}