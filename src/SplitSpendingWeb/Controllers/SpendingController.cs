using Microsoft.AspNetCore.Mvc;

namespace SplitSpendingWeb.Controllers;

[Route("api/spending")]
public class SpendingController : Controller {

    public SpendingController()
    {
        
    }

    [HttpGet]
    public IActionResult Get() {
        var result = new {id = 1, name = "Alex"};
        return Ok(result);
    }
}