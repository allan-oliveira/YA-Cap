using DotNetCore.CAP;
using DotNetCore.CAP.Messages;
using Microsoft.AspNetCore.Mvc;
using YACap.Data;

namespace YACap.API.Controllers;
public class ConsumerController : Controller
{
    [NonAction]
    [CapSubscribe("test.show.time", Group = "group1")]
    public void ReceiveMessage(Person p)
    {
        Console.WriteLine($@"{DateTime.Now} Subscriber invoked, Info: {p}");
    }

    [NonAction]
    [CapSubscribe("test.show.time", Group = "group1")]
    public void ReceiveMessage2(Person p, [FromCap] CapHeader header)
    {
        var id = header[Headers.MessageId];
        Console.WriteLine($@"{DateTime.Now} Subscriber invoked, Info: {p}");
    }
}