using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Tasks;
using TaskManager.Infrastructure.Dtos;

namespace TaskManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ISender sender;

        public TasksController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await this.sender.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDto payload)
        {
            await this.sender.Send(new CreateTaskCommand(payload));
            return Ok();
        }
    }
}
