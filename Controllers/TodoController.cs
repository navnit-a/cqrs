using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTodoItem([FromBody] TodoItem todoItem)
        {
            var command = new AddTodoItem { TodoItem = todoItem };
            var result = await _mediator.Send(command);

            if (result)
            {
                return Ok("Todo item added successfully.");
            }

            return BadRequest("Failed to add the todo item.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodoItems()
        {
            var query = new GetAllTodoItems();
            var todoItems = await _mediator.Send(query);
            return Ok(todoItems);
        }
    }
}
