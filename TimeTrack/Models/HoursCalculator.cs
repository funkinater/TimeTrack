using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class HoursCalculator
    {
        public DataTable AddHoursColumn(DataTable punchesTable)
        {
            punchesTable.Columns.Add("Hours", typeof(double));
            double totalHours = 0;

            foreach (DataRow row in punchesTable.Rows)
            {

                var startTime = row["Clock In"].ToString();
                var endTime = (row["Clock Out"].ToString()=="-:--") ? null : row["Clock Out"].ToString();
                var lunchOut = (row["Out to Lunch"].ToString()=="-:--") ? null : row["Out to Lunch"].ToString();
                var lunchIn = (row["Back from Lunch"].ToString() == "-:--") ? null : row["Back from Lunch"].ToString();

                var ts = new TimeSpan();
                var lunchHour = new TimeSpan();

                if (endTime != null)
                {
                    ts = DateTime.Parse(endTime).Subtract(DateTime.Parse(startTime));
                    if (lunchOut != null && lunchIn != null)
                    {
                        lunchHour = DateTime.Parse(lunchIn).Subtract(DateTime.Parse(lunchOut));
                        ts -= lunchHour;
                    }
                }

                var hours = ts.TotalMinutes / 60;
                totalHours += hours;
                row["Hours"] = hours;
            }

            

            return (punchesTable);
        }
    }
}