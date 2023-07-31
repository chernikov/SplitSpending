using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SplitSpendingWeb.Business.Commands;
using SplitSpendingWeb.Business.Queries;
using SplitSpendingWeb.Dtos;

namespace SplitSpendingWeb.Controllers;

[Route("api/spend")]
public class SpendController : Controller {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<SpendController> _logger;

    public SpendController(IMediator mediator, IMapper mapper, ILogger<SpendController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get() 
    {
        var command = new GetSpendingDetailsQuery();
        var response = await _mediator.Send(command);

        var result = _mapper.Map<IEnumerable<SpendingReadDto>>(response);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSpendingCommand command) 
    {
        try 
        {
            var result = await _mediator.Send(command);
            return Created("", result);

        } catch (Exception ex) {
            _logger.LogError($"--> Can't add spending. {command.Name} {command.Amount}\r\n Exception: {ex.Message}");
            return BadRequest();
        }
    }
}