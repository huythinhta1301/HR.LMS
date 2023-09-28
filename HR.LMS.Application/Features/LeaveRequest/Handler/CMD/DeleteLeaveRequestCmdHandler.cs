using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.Exception;
using HR.LMS.Application.Features.LeaveRequest.Request.CMD;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveRequest.Handler.CMD
{
    public class DeleteLeaveRequestCmdHandler : IRequestHandler<DeleteLeaveRequestCmd, BaseResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveRequestCmdHandler(ILeaveRequestRepository repo, IMapper mapper)
        {
            _leaveRequestRepository = repo;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteLeaveRequestCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var leaveReq = await _leaveRequestRepository.GetAsync(request.Id);
            if(leaveReq == null)
            {
                res.Code = Helper.Code.NOT_FOUND;
                res.Message = $"{request.Id} IS NOT EXIST";
                throw new NotFoundExcep(nameof(LeaveRequests), request.Id);
            }
            await _leaveRequestRepository.DeleteAsync(leaveReq);
            res.Code = Helper.Code.SUCCESS;
            res.IsSuccess = true;
            res.Message = "SUCCESS";
            return res;
        }
    }
}
