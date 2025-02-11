using InfoCom.MediatR.MediatRService.ScheduleService;
using InfoCom.Ui.Models.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InfoCom.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetScheduleQuery());
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var response = await _mediator.Send(new GetScheduleByIdQuery(id));
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<ActionResult> Insertasync(ScheduleModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(new InsertScheduleCommand(model));
                if (response != null)
                {
                    return Ok(response);
                }
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Updateasync([FromBody] ScheduleModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var response = await _mediator.Send(new UpdateScheduleCommand(id, model));
                if (response != null)
                {
                    return Ok(response);
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deleteasync(int id)
        {
            var response = await _mediator.Send(new DeleteScheduleCommand(id));
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
