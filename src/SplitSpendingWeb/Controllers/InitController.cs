using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitSpendingWeb.Business.Commands;

namespace SplitSpendingWeb.Controllers;


[Route("api/init")]
public class InitController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<InitController> _logger;

    public InitController(IMediator mediator, ILogger<InitController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]

    public async Task<IActionResult> Post([FromBody] InitCommand command) 
    {
        _logger.LogTrace($"--> Init {command.Name}");
        var result = await _mediator.Send(command);

        if (result > 0) {
            _logger.LogTrace($"{command.Name} Inited");
            return Created("", result);
        }
        return NoContent();
    }
}