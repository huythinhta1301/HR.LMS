using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.Exception;
using HR.LMS.Application.Features.LeaveTypes.Request.CMD;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveTypes.Handler.CMD
{
    public class DeleteLeaveTypeCmdHandler : IRequestHandler<DeleteLeaveTypeCmd, BaseResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveTypeCmdHandler(ILeaveTypeRepository repo , IMapper mapper)
        {
            _leaveTypeRepository = repo;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteLeaveTypeCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var leaveReq = await _leaveTypeRepository.GetAsync(request.Id);
            if(leaveReq == null)
            {
                res.Code = Helper.Code.NOT_FOUND;
                res.Message = "";
                throw new NotFoundExcep(nameof(LeaveTypes),request.Id);
            }
            await _leaveTypeRepository.DeleteAsync(leaveReq);
            return res;
        }
    }
}
