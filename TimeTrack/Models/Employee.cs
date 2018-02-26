using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }

        public Position Position { get; set; }

        public int PositionId { get; set; }
        public string WorkHours { get; set; }
        public double Salary { get; set; }
        public bool OnProbation { get; set; }
        public Supervisor Supervisor { get; set; }
        public int SupervisorId { get; set; }
    }
}