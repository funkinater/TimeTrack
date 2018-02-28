using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using TimeTrack.Dtos;
using TimeTrack.Models;

namespace TimeTrack.Controllers.Api
{
    public class ClockPunchController : ApiController
    {

        private EmployeeContext _context;

        public ClockPunchController()
        {
                _context = new EmployeeContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateClockPunch(ClockPunchDto clockPunchDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clockPunch = Mapper.Map<ClockPunch>(clockPunchDto);
            _context.ClockPunches.Add(clockPunch);
            _context.SaveChanges();

            clockPunchDto.Id = clockPunch.Id;

            var employee = _context.Employees.Single(emp => emp.Id == clockPunch.EmployeeId);
            clockPunchDto.Employee = Mapper.Map<EmployeeDto>(employee);

            return Created(new Uri(Request.RequestUri + "/" + clockPunch.Id), clockPunchDto);
        }

        //GET /api/ClockPunch/1
        public IHttpActionResult GetClockPunch(int id)
        {
            var clockPunch = _context.ClockPunches.Include(punch => punch.Employee)
                .SingleOrDefault(cp => cp.Id == id);

            if (clockPunch == null)
                return NotFound();

            return Ok(Mapper.Map<ClockPunchDto>(clockPunch));
        }
    }
}
