using DotNetCore.CAP;
using DotNetCore.CAP.Messages;
using Microsoft.AspNetCore.Mvc;
using YACap.Data;

namespace YACap.API.Controllers;
public class ConsumerController : Controller
{
    [NonAction]
    [CapSubscribe("user.cmd.create", Group = "user-create-queue")]
    public void ReceiveMessage(Person p)
    {
        Console.WriteLine($@"{DateTime.Now} Subscriber invoked, Info: {p}");
    }
}