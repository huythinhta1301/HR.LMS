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
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDTO>>
    {
        private readonly ILeaveTypeRepository _leaveType;
        private readonly IMapper _mapper;
        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveType, IMapper mapper)
        {
            _leaveType = leaveType;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDTO>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveType.GetLeaveTypeWithDetail();
            return _mapper.Map<List<LeaveTypeDTO>>(leaveTypes);
        }
    }
}
