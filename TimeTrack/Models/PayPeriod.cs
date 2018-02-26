using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class PayPeriod
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //Holiday credit hours - add any "holiday/early release" hours that
        //occured during this pay period when calculating hours paid
        public double HolidayCreditHours { get; set; }
    }
}