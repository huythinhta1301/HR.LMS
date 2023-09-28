using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs;
using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Application.Features.LeaveRequest.Request.Queries;
using HR.LMS.Application.Features.LeaveTypes.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestList, List<LeaveRequestListDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public GetLeaveRequestListHandler(ILeaveRequestRepository leaveRequestRepo, IMapper mapper)
        {
           _leaveRequestRepository= leaveRequestRepo;
            _mapper= mapper;
        }

        public async Task<List<LeaveRequestListDTO>> Handle(GetLeaveRequestList request, CancellationToken cancellationToken)
        {
            var leaveReq = await _leaveRequestRepository.GetLeaveRequestWithDetail();
            return _mapper.Map<List<LeaveRequestListDTO>>(leaveReq);
        }
    }
}
