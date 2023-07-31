using Microsoft.AspNetCore.Mvc;
using SplitSpendingWeb.Business.Queries;

namespace SplitSpendingWeb.Controllers;

[Route("api/summary")]
public class SummaryController : Controller {
    private IMediator _mediator;

    public SummaryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _mediator.Send(new GetSummary()));
}