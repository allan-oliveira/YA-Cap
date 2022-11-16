using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YACap.Data;

namespace YACap.API.Controllers;

public class PublishController : Controller
{
    private readonly ICapPublisher _capBus;
    private readonly AppDbContext _dbContext;
    public PublishController(ICapPublisher capPublisher, AppDbContext dbContext)
    {
        _capBus = capPublisher;
        _dbContext = dbContext;
    }

    [Route("~/send")]
    public IActionResult SendMessage()
    {
        using (_dbContext.Database.BeginTransaction(_capBus, autoCommit: true))
        {
            var person = new Person() { Name = "Foo" };
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            _capBus.Publish("test.show.time", person);
        }
        return Ok();
    }
}
