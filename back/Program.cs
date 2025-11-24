using Microsoft.Extensions.Options;
using Npgsql;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

IConfiguration config = builder.Configuration;

string connectionString = config.GetConnectionString("default")!;



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,

                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine($"String {config.GetConnectionString("default")}");
builder.Services.AddTransient<DbConnection>(sp => new NpgsqlConnection(connectionString));



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
