using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using TimeTrack.Models;

namespace TimeTrack.ViewModels
{
    public class EmployeePunchViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<ClockPunch> ClockPunches { get; set; }

        public bool ClockedIn
        {
            get
            {
                var punches = from p in ClockPunches
                    where p.PunchType.Name == "Clock In"
                    select p;

                if (punches.Any())
                    return true;
                return false;
            }
        }

        public bool ClockedOut
        {
            get
            {
                var punches = from p in ClockPunches
                    where p.PunchType.Name == "Clock Out"
                    select p;

                if (punches.Any())
                    return true;
                return false;
            }
        }

        public bool OutToLunch
        {
            get
            {

                var punches = from p in ClockPunches
                    where p.PunchType.Name == "Out to Lunch"
                    select p;

                if (punches.Any())
                    return true;
                return false;
            }
        }

        public bool BackFromLunch
        {
            get
            {

                var punches = from p in ClockPunches
                    where p.PunchType.Name == "Back from Lunch"
                    select p;

                if (punches.Any())
                    return true;
                return false;
            }
        }

       
    }
}