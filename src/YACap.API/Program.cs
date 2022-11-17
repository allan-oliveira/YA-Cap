using Microsoft.EntityFrameworkCore;
using YACap.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCap(x =>
{
    x.Version = "v1";
    x.UseEntityFramework<AppDbContext>();
    x.UseRabbitMQ(y =>
    {
        y.HostName = builder.Configuration["RabbitMQ:HostName"];
        y.Port = int.Parse(builder.Configuration["RabbitMQ:Port"]);
        y.UserName = builder.Configuration["RabbitMQ:UserName"];
        y.Password = builder.Configuration["RabbitMQ:Password"];
        y.VirtualHost = builder.Configuration["RabbitMQ:VirtualHost"];
        y.ExchangeName = builder.Configuration["RabbitMQ:ExchangeName"];
    });
    x.UseDashboard();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
