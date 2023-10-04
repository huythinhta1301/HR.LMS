using HR.LMS.Application.DTOs.LeaveType;
using HR.LMS.Application.Features.LeaveTypes.Request.CMD;
using HR.LMS.Application.Features.LeaveTypes.Request.Queries;
using HR.LMS.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LMS.API.Controller.LeaveManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _me;
        public LeaveTypeController(IMediator media)
        {
            _me = media;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> LIST()
        {
            var list = await _me.Send(new GetLeaveTypeListRequest());
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> GET_ID(int id)
        {
            var leaveType = await _me.Send(new GetLeavesTypeDetailRequest { Id = id });
            return Ok(leaveType);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CREATE([FromBody] CreateLeaveTypeDTO dto)
        {
            var createLEaveType = new CreateLeaveTypeCmd { CreateLeaveTypeDTO = dto };
            var resp = await _me.Send(createLEaveType);
            return resp;
        }

        [HttpPut]
        public async Task<ActionResult> UPDATE([FromBody] LeaveTypeDTO dto)
        {
            var leaveType = new UpdateLeaveTypeCmd { LeaveTypeDTO = dto };
            await _me.Send(leaveType);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DELETE(int id)
        {
            var delLeaveType = await _me.Send(new DeleteLeaveTypeCmd { Id = id });
            return NoContent();
        }
    }
}
