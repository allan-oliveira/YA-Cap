using Microsoft.EntityFrameworkCore;

namespace YACap.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

public class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public override string ToString()
    {
        return $"Name:{Name}, Id:{Id}";
    }
}