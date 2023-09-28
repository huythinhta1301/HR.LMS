using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.Exception;
using HR.LMS.Application.Features.LeaveAllocation.Request.CMD;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveAllocation.Handler.CMD
{
    public class DeleteLeaveAllocationCmdHandler : IRequestHandler<DeleteLeaveAllocationCmd, BaseResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveAllocationCmdHandler(ILeaveAllocationRepository repo, IMapper mapper)
        {
            _leaveAllocationRepository = repo;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(DeleteLeaveAllocationCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var leaveAllo = await _leaveAllocationRepository.GetAsync(request.Id);
            if(leaveAllo == null)
            {
                res.Message = "NOT FOUND";
                res.Code = Helper.Code.NOT_FOUND;
                throw new NotFoundExcep(nameof(LeaveAllocations),request.Id);
            }
            await _leaveAllocationRepository.DeleteAsync(leaveAllo);
            res.Message = "SUCCESS";
            res.Code = Helper.Code.SUCCESS;
            res.IsSuccess = true;
            return res;
        }
    }
}
