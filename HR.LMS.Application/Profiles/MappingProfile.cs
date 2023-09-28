using AutoMapper;
using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Application.DTOs.LeaveType;
using HR.LMS.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using HR.LMS.Application.DTOs.LeaveAllocation;

namespace HR.LMS.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<LeaveRequests, LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveRequests, LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveAllocations, LeaveAllocationDTO>().ReverseMap();
            CreateMap<LeaveTypes, LeaveTypeDTO>().ReverseMap();
        }
    }
}
