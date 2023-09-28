using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveAllocation;
using HR.LMS.Application.DTOs.LeaveAllocation.Validator;
using HR.LMS.Application.Features.LeaveAllocation.Request.CMD;
using HR.LMS.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveAllocation.Handler.CMD
{
    public class UpdateLeaveAllocationCmdHandler : IRequestHandler<UpdateLeaveAllocationCmd, BaseResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepo;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        public UpdateLeaveAllocationCmdHandler(ILeaveAllocationRepository leaveAllocation, IMapper mapper, ILeaveTypeRepository leaveTypeRepo)
        {
            _leaveAllocationRepo = leaveAllocation;
            _mapper = mapper;
            _leaveTypeRepo = leaveTypeRepo;

        }

        public async Task<BaseResponse> Handle(UpdateLeaveAllocationCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var checkValid = new UpdateLeaveAllocationDTOValid(_leaveTypeRepo);
            var result = await checkValid.ValidateAsync(request.leaveAllocationDTO);
            if(result == null)
            {
                res.Message = "PLEASE CHECK AGAIN";
                res.Code = Helper.Code.VALIDATION_FAIL;
                res.Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            }
            var leaveAllo = await _leaveAllocationRepo.GetLeaveAllocationWithDetail(request.leaveAllocationDTO.Id);
            if(leaveAllo == null)
            {
                res.Message = "PLEASE CHECK AGAIN";
                res.Code = Helper.Code.NOT_FOUND;
            }
            
            leaveAllo = _mapper.Map(request.leaveAllocationDTO, leaveAllo);
            await _leaveAllocationRepo.UpdateAsync(leaveAllo);

            res.IsSuccess = true;
            res.Message = "SUCCESS";
            res.Code = Helper.Code.SUCCESS;
            res.Id = request.leaveAllocationDTO.Id;
            return res;
        }
    }
}
