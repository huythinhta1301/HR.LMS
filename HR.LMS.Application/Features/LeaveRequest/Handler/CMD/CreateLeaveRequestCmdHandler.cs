using AutoMapper;
using HR.LMS.Application.Contracts.Infranstructure;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Application.DTOs.LeaveRequest.Validator;
using HR.LMS.Application.Exception;
using HR.LMS.Application.Features.LeaveRequest.Request.CMD;
using HR.LMS.Application.Models;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveRequest.Handler.CMD
{
    public class CreateLeaveRequestCmdHandler : IRequestHandler<CreateLeaveRequestCmd, BaseResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepo;
        private readonly ILeaveTypeRepository _leaveType;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        public CreateLeaveRequestCmdHandler(ILeaveRequestRepository leaveRequestRepo, IMapper mapper, ILeaveTypeRepository leaveTypeRepo, IEmailSender email)
        {
            _leaveRequestRepo= leaveRequestRepo;
            _mapper= mapper;
            _leaveType = leaveTypeRepo;
            _emailSender= email;
        }

        public async Task<BaseResponse> Handle(CreateLeaveRequestCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var valid = new CreateLeaveRequestDTOValid(_leaveType);
            var isValid = await valid.ValidateAsync(request.CreateLeaveRequestDTO);
            if(isValid.IsValid)
            {
                var leaveReq = _mapper.Map<LeaveRequests>(request.CreateLeaveRequestDTO);
                leaveReq = await _leaveRequestRepo.AddAsync(leaveReq);
                res.IsSuccess = true;
                res.Message = "SUCCESS";
                res.Code = Helper.Code.SUCCESS;
                res.Id = leaveReq.Id;
                var email = new Email
                {
                    To = "AAA@gmail.com",
                    Content = $"Your form has been submitted success, time from {request.CreateLeaveRequestDTO.StartDate} - {request.CreateLeaveRequestDTO.EndDate}",
                    Title = "Leave Request Form Submitted"
                };
                try
                {
                    await _emailSender.SendEmail(email);
                }
                catch
                {

                }
                
            }
            else
            {
                res.Code = Helper.Code.FAILURE;
                res.Message = "FAIL";
                res.IsSuccess= false;
                res.Errors = isValid.Errors.Select(c => c.ErrorMessage).ToList();
                throw new ValidationExcep(isValid);
            }
            return res;

        }
    }
}
