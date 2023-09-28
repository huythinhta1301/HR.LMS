using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Application.Features.LeaveRequest.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveRequest.Handler.Queries
{
    public class GetLeaveRequestDetailHandler : IRequestHandler<GetLeaveRequestDetail, LeaveRequestListDTO>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly IMapper _mapper;
        public GetLeaveRequestDetailHandler( ILeaveRequestRepository leaveRequestRepo, IMapper mapper)
        {
            _leaveRequestRepo= leaveRequestRepo;
            _mapper= mapper;
        }
        public async Task<LeaveRequestListDTO> Handle(GetLeaveRequestDetail request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepo.GetLeaveRequestWithDetail(request.Id);
            return _mapper.Map<LeaveRequestListDTO>(leaveRequest); 
        }
    }
}
