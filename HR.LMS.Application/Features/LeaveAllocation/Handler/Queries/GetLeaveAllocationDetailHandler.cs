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
    public class GetLeaveAllocationDetailHandler : IRequestHandler<GetLeaveAllocationDetail, LeaveAllocationDTO>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationDetailHandler(ILeaveAllocationRepository leaveAllocationRepo, IMapper mapper)
        {
            _leaveAllocationRepository= leaveAllocationRepo;
            _mapper= mapper;
        }

        public async Task<LeaveAllocationDTO> Handle(GetLeaveAllocationDetail request, CancellationToken cancellationToken)
        {
            var leaveAllocationDetail = await _leaveAllocationRepository.GetLeaveAllocationWithDetail(request.Id);
            return _mapper.Map<LeaveAllocationDTO>(leaveAllocationDetail);
        }
    }
}
