using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace YACap.API.Controllers;

public class PublishController : Controller
{
    [Route("~/send")]
    public IActionResult SendMessage([FromServices] ICapPublisher capBus)
    {
        var header = new Dictionary<string, string>()
        {
            ["my.header.first"] = "first",
            ["my.header.second"] = "second"
        };

        capBus.Publish("test.show.time", DateTime.Now, header);

        return Ok();
    }
}
