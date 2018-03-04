using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TimeTrack.Models;
using TimeTrack.ViewModels;

namespace TimeTrack.Controllers
{
    public class ClockController : Controller
    {
        private EmployeeContext _context;

        public ClockController()
        {
            _context = new EmployeeContext();
            
        }
        // GET: Clock
        public ActionResult Index(string userName)
        {
            string cName = 
                (userName.IsNullOrWhiteSpace()) ? System.Environment.UserName : userName;

            var userInDb = _context.Employees.SingleOrDefault(e => e.Name == cName);
            if (userInDb == null)
            {
                var newUser = new Employee
                {
                    Name = cName,
                    PositionId = 6,
                    SupervisorId = 1,
                    WorkHours = "8:30|5:30",
                    OnProbation = false
                };
                _context.Employees.Add(newUser);
                _context.SaveChanges();
                userInDb = newUser;
            }

            var week = new Week();

            //clock punches for this employee, today
            var punches = _context.ClockPunches
                .Include(p => p.PunchType)
                .Where(p=>p.Employee.Id == userInDb.Id &&
                         DbFunctions.TruncateTime(p.PunchEventTime) ==
                          DbFunctions.TruncateTime(DateTime.Now));

            //clock punches for this employee, this week
            var punchesWeek = _context.ClockPunches
                .Include(p => p.PunchType).AsEnumerable()
                .Where(p => p.EmployeeId == userInDb.Id &&
                            p.PunchEventTime.Date >= week.Start.Date &&
                            p.PunchEventTime.Date <= week.End.Date);

            var dt = new Pivot().PivotTable(punchesWeek);
            
            var viewModel = new EmployeePunchViewModel
            {
                Employee = userInDb,
                ClockPunches = punches,
                ClockPunchesWeek = punchesWeek,
                Week = week,
                PunchesThisWeek = dt
            };

            Console.WriteLine(userInDb);
            return View(viewModel);
        }
    }
}