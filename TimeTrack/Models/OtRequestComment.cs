using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTrack.Models
{
    public class OtRequestComment
    {
        public int Id { get; set; }
        public OtRequest OtRequest { get; set; }
        public int OtRequestId { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
    }
}