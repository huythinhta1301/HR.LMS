using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveType.Validators;
using HR.LMS.Application.Exception;
using HR.LMS.Application.Features.LeaveTypes.Request.CMD;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveTypes.Handler.CMD
{
    public class CreateLeaveTypeCmdHandler : IRequestHandler<CreateLeaveTypeCmd, BaseResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCmdHandler(ILeaveTypeRepository leaveTypeRepo, IMapper mapper)
        {
            _leaveTypeRepo = leaveTypeRepo;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreateLeaveTypeCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var validate = new CreateLeaveTypeDTOValid();
            var validResult = await validate.ValidateAsync(request.CreateLeaveTypeDTO);
            if (validResult.IsValid)
            {
                var leaveType = _mapper.Map<Domain.LeaveTypes>(request.CreateLeaveTypeDTO);
                leaveType = await _leaveTypeRepo.AddAsync(leaveType);
                res.IsSuccess = true;
                res.Code = Helper.Code.SUCCESS;
                res.Message = "SUCCESS";
                res.Id = leaveType.Id;
            }
            else
            {
                res.Errors = validResult.Errors.Select(c  => c.ErrorMessage).ToList();
                res.Message = "";
                res.Code = Helper.Code.VALIDATION_FAIL;
                throw new ValidationExcep(validResult);
            }
            return res;
        }
    }
}
