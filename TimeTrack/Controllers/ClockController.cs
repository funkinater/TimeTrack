using System;
using System.Collections.Generic;
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

            var punches = _context.ClockPunches
                .Include(p => p.PunchType)
                .Where(p=>p.Employee.Id == userInDb.Id &&
                         DbFunctions.TruncateTime(p.PunchEventTime) ==
                          DbFunctions.TruncateTime(DateTime.Now));

            //var punches = from p in allPunches
            //    where p.Employee.Id == userInDb.Id && 
            //          DbFunctions.TruncateTime(p.PunchEventTime) == 
            //          DbFunctions.TruncateTime(DateTime.Now)
            //    select p;
            

                var viewModel = new EmployeePunchViewModel
            {
                Employee = userInDb,
                ClockPunches = punches

            };

            Console.WriteLine(userInDb);
            return View(viewModel);
        }
    }
}