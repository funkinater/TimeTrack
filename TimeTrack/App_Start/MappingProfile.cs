using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TimeTrack.Dtos;
using TimeTrack.Models;

namespace TimeTrack.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            CreateMap<Employee, EmployeeDto>();
            CreateMap<ClockPunch, ClockPunchDto>();

            //DTO to Domain
            CreateMap<EmployeeDto, Employee>()
                .ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<ClockPunchDto,ClockPunch>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}