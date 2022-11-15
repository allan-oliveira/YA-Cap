using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace YACap.API.Controllers;
public class ConsumerController : Controller
{
    [NonAction]
    [CapSubscribe("test.show.time")]
    public void ReceiveMessage(DateTime time, [FromCap] CapHeader header)
    {
        Console.WriteLine("message time is:" + time);
        Console.WriteLine("message firset header :" + header["my.header.first"]);
        Console.WriteLine("message second header :" + header["my.header.second"]);
    }
}