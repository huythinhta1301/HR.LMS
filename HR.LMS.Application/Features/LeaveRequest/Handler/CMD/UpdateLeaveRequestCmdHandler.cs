using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveRequest.Validator;
using HR.LMS.Application.Exception;
using HR.LMS.Application.Features.LeaveRequest.Request.CMD;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveRequest.Handler.CMD
{
    public class UpdateLeaveRequestCmdHandler : IRequestHandler<UpdateLeaveRequestCmd, BaseResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveType;
        private readonly IMapper _mapper;
        public UpdateLeaveRequestCmdHandler(ILeaveRequestRepository repo, IMapper mapper, ILeaveTypeRepository leaveType)
        {
            _leaveRequestRepository = repo;
            _mapper = mapper;
            _leaveType = leaveType;
        }
        public async Task<BaseResponse> Handle(UpdateLeaveRequestCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var valid = new UpdateLeaveRequestDTOValid(_leaveType);
            var validResult = await valid.ValidateAsync(request.UpdateLeaveRequestDTO);
            if(!validResult.IsValid)
            {
                res.Message = "PLEASE CHECK AGAIN";
                res.Code = Helper.Code.VALIDATION_FAIL;
                res.Errors = validResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationExcep(validResult);
            }
            var leaveReq = await _leaveRequestRepository.GetLeaveRequestWithDetail(request.Id);
            if(leaveReq == null)
            {
                res.Message = "PLEASE CHECK AGAIN";
                res.Code = Helper.Code.NOT_FOUND;
                res.Errors = validResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new NotFoundExcep(nameof(LeaveRequests),request.Id);
            }
            if (request.UpdateLeaveRequestDTO != null)
            {
                leaveReq = _mapper.Map(request.UpdateLeaveRequestDTO, leaveReq);
                await _leaveRequestRepository.UpdateAsync(leaveReq);
            }
            else if(request.ChangeApprovalStatusDTO != null)
            {
                await _leaveRequestRepository.UpdateApprovedStatus(leaveReq, request.ChangeApprovalStatusDTO.Approved);
            }
           
            return res;
        }
    }
}
