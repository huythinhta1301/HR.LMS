using AutoMapper;
using HR.LMS.Application.Contracts.Irepo;
using HR.LMS.Application.DTOs.LeaveAllocation.Validator;
using HR.LMS.Application.Exception;
using HR.LMS.Application.Features.LeaveAllocation.Request.CMD;
using HR.LMS.Application.Response;
using HR.LMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LMS.Application.Features.LeaveAllocation.Handler.CMD
{
    public class CreateLeaveAllocationCmdHandler : IRequestHandler<CreateLeaveAllocationCmd, BaseResponse>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveAllocationCmdHandler(ILeaveAllocationRepository leaveAllocationRepo, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepo;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<BaseResponse> Handle(CreateLeaveAllocationCmd request, CancellationToken cancellationToken)
        {
            var res = new BaseResponse();
            var checkValid = new CreateLeaveAllocationDTOValid(_leaveTypeRepository);
            var result = await checkValid.ValidateAsync(request.createLeaveAllocationDTO);
            if (!result.IsValid)
            {
                res.Message = "FAIL";
                res.Code = Helper.Code.VALIDATION_FAIL;
                res.Errors = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationExcep(result);
            }
            var leaveAllocation = _mapper.Map<LeaveAllocations>(request.createLeaveAllocationDTO);
            leaveAllocation = await _leaveAllocationRepository.AddAsync(leaveAllocation);
            res.IsSuccess = true;
            res.Code = Helper.Code.SUCCESS;
            res.Message = "SUCCESS";
            return res;

        }
    }
}
