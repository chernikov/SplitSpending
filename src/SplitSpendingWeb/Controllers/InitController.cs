using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitSpendingWeb.Business.Commands;

namespace SplitSpendingWeb.Controllers;


[Route("api/init")]
public class InitController : Controller
{
    private readonly IMediator _mediator;

    public InitController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]

    public async Task<IActionResult> Post([FromBody] InitCommand command) 
    {
        Console.WriteLine($"--> Init {command.Name}");
        var result = await _mediator.Send(command);

        if (result > 0) {
            Console.WriteLine($"{command.Name} Inited");
            return Created("", result);
        }
        return NoContent();
    }
}