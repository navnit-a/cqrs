using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SampleController : ControllerBase
  {
    private readonly IMediator _mediator;

    public SampleController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpGet]
    public IActionResult GetSampleResponse()
    {
      return Ok("Sample response");
    }
  }
}
