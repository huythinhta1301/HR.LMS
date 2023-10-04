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
    public class UpdateLeaveTypeCmdHandler : IRequestHandler<UpdateLeaveTypeCmd, BaseResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveTypeCmdHandler(ILeaveTypeRepository leaveTypeRepo, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepo;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(UpdateLeaveTypeCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var valid = new UpdateLeaveTypeDTOValid();

            var validResult = await valid.ValidateAsync(request.LeaveTypeDTO);
            if(!validResult.IsValid)
            {
                res.Message = "";
                res.Code = Helper.Code.VALIDATION_FAIL;
                res.Errors = validResult.Errors.Select(c => c.ErrorMessage).ToList();
                throw new ValidationExcep(validResult);
            }

            var leaveTypeCmd = await _leaveTypeRepository.GetLeaveTypeWithDetail(request.LeaveTypeDTO.Id);
            if(leaveTypeCmd == null)
            {
                res.Message = "";
                res.Code = Helper.Code.FAILURE;
                throw new NotFoundExcep(nameof(LeaveTypes),request.LeaveTypeDTO.Id);
            }

            _mapper.Map(request.LeaveTypeDTO, leaveTypeCmd);
            await _leaveTypeRepository.UpdateAsync(leaveTypeCmd);
            return res;

        }
    }
}
