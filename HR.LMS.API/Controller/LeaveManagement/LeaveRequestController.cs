using HR.LMS.Application.DTOs.LeaveRequest;
using HR.LMS.Application.Features.LeaveRequest.Request.CMD;
using HR.LMS.Application.Features.LeaveRequest.Request.Queries;
using HR.LMS.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.LMS.API.Controller.LeaveManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _media;
        public LeaveRequestController(IMediator media)
        {
            _media = media;
        }
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDTO>>> LIST()
        {
            var resp = await _media.Send(new GetLeaveRequestList());
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDTO>> GET(int id)
        {
            var resp = await _media.Send(new GetLeaveRequestDetail { Id = id });
            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> CREATE([FromBody] CreateLeaveRequestDTO dto)
        {
            var leaveRequest = new CreateLeaveRequestCmd { CreateLeaveRequestDTO = dto };
            var res = await _media.Send(leaveRequest);
            return Ok(res);
        }

        [HttpPut]
        public async Task<ActionResult<BaseResponse>> UPDATE([FromBody] UpdateLeaveRequestDTO dto)
        {
            var leaveRequest = new UpdateLeaveRequestCmd { UpdateLeaveRequestDTO = dto };
            var res = await _media.Send(leaveRequest);
            return Ok(res);
        }

        [HttpDelete]
        public async Task<ActionResult<BaseResponse>> DELETE(int id)
        {
            var leaveReq = new DeleteLeaveRequestCmd { Id = id };
            var res = await _media.Send(leaveReq);
            return Ok(res);
        }

        [HttpPut("changeapproval/{id}")]
        public async Task<ActionResult<BaseResponse>> UPDATE_STATUS(int id, [FromBody] ChangeApprovalStatusDTO dto)
        {
            var leaveRe = new UpdateLeaveRequestCmd { Id = id, ChangeApprovalStatusDTO = dto };
            var res = await _media.Send(leaveRe);
            return Ok(res);
        }
    }
}
