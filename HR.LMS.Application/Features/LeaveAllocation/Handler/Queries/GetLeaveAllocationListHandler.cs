using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveAllocation;
using HR.LMS.Application.Features.LeaveAllocation.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveAllocation.Handler.Queries
{
    public class GetLeaveAllocationListHandler : IRequestHandler<GetLeaveAllocationList, List<LeaveAllocationDTO>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationListHandler(ILeaveAllocationRepository leaveAllocationRepo, IMapper mapper)
        {
            _leaveAllocationRepository= leaveAllocationRepo;
            _mapper= mapper;
        }
        public async Task<List<LeaveAllocationDTO>> Handle(GetLeaveAllocationList request, CancellationToken cancellationToken)
        {
            var listLeaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetail();
            return _mapper.Map<List<LeaveAllocationDTO>>(listLeaveAllocation);
        }
    }
}
