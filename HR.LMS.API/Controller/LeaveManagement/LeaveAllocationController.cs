using HR.LMS.Application.DTOs.LeaveAllocation;
using HR.LMS.Application.Features.LeaveAllocation.Request.CMD;
using HR.LMS.Application.Features.LeaveAllocation.Request.Queries;
using HR.LMS.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LMS.API.Controller.LeaveManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _media;
        public LeaveAllocationController(IMediator media)
        {
            _media = media;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> LIST()
        {
            var res = await _media.Send(new GetLeaveAllocationList());
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDTO>> GET(int id)
        {
            var allo = await _media.Send(new GetLeaveAllocationDetail { Id = id });
            return Ok(allo);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CREATE([FromBody] CreateLeaveAllocationDTO dto)
        {
            var cmd = new CreateLeaveAllocationCmd { createLeaveAllocationDTO = dto };
            var res = await _media.Send(cmd);
            return Ok(res);
        }

    }
}
