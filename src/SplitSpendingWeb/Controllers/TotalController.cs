using Microsoft.AspNetCore.Mvc;
using SplitSpendingWeb.Business.Queries;

namespace SplitSpendingWeb.Controllers;

[Route("api/total")]
public class TotalController : Controller 
{
    private readonly IMediator _mediator;

    public TotalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetTotal()));

}