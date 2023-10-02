using HR.LMS.Application.DTOs.LeaveType;
using HR.LMS.Application.Features.LeaveTypes.Request.CMD;
using HR.LMS.Application.Features.LeaveTypes.Request.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LMS.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypeDTO>>> GET()
        {
            GetLeaveTypeListRequest request = new GetLeaveTypeListRequest();
            var leaveType = await _mediator.Send(request);
            return Ok(leaveType);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDTO>> GET(int id)
        {
            GetLeavesTypeDetailRequest request = new GetLeavesTypeDetailRequest();
            var leaveTypeDetail = await _mediator.Send(request.Id = id);
            return Ok(leaveTypeDetail);
        }
        [HttpPost]
        public async Task<ActionResult> CREATE([FromBody] CreateLeaveTypeDTO leaveType )
        {
            var create = new CreateLeaveTypeCmd { CreateLeaveTypeDTO = leaveType };
            var resp = await _mediator.Send(create);
            return Ok(resp);
        }
        [HttpPut]
        public async Task<ActionResult> PUT([FromBody] LeaveTypeDTO leaveType)
        {
            var update = new UpdateLeaveTypeCmd { LeaveTypeDTO = leaveType };
            await _mediator.Send(update);
            return NoContent();
        }
    }
}
