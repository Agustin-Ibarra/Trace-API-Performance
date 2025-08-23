using Microsoft.EntityFrameworkCore;
using TraceApiPerformance.Api;

var builder = WebApplication.CreateBuilder(args);
var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (stringConnection != null)
{
  builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(stringConnection));

}
else
{
  Console.WriteLine($"stringConnection is null");
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();