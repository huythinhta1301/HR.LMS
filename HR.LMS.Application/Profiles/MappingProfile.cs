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
            #region [Leave Request]
            CreateMap<LeaveRequests, LeaveRequestListDTO>().ReverseMap();
            CreateMap<LeaveRequests, CreateLeaveRequestDTO>().ReverseMap();
            #endregion
            #region [Leave Allocation]
            CreateMap<LeaveAllocations, LeaveAllocationDTO>().ReverseMap();
            #endregion
            #region [Leave Type]
            CreateMap<LeaveTypes, LeaveTypeDTO>().ReverseMap();
            CreateMap<LeaveTypes, CreateLeaveTypeDTO>().ReverseMap();
            #endregion
        }
    }
}
