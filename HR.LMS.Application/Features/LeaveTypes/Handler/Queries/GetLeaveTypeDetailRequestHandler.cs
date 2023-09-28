using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveType;
using HR.LMS.Application.Features.LeaveTypes.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveTypes.Handler.Queries
{
    public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeavesTypeDetailRequest, LeaveTypeDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepo, IMapper mapper)
        {
            _leaveTypeRepository= leaveTypeRepo;
            _mapper= mapper;
        }
        public async Task<LeaveTypeDTO> Handle(GetLeavesTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetLeaveTypeWithDetail(request.Id);
            return _mapper.Map<LeaveTypeDTO>(leaveType);
        }
    }
}
