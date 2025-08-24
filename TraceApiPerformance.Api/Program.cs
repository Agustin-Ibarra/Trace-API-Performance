using Microsoft.EntityFrameworkCore;
using TraceApiPerformance.Api.Data;
using TraceApiPerformance.Api.Repository;

var builder = WebApplication.CreateBuilder(args);
var stringConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (stringConnection != null)
{
  Console.WriteLine(stringConnection);
  builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(stringConnection));
  builder.Services.AddScoped<MovieRespository>();
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
app.UseRouting();
app.MapControllers();

app.Run();