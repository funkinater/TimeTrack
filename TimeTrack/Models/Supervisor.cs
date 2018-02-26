using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class Supervisor
    {
        public int Id { get; set; }

        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }
    }
}