using ElectionManagement.WebAPI;
using ElectionManagement.WebAPI.Repository;
using ElectionManagement.WebAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ElectionManagementDbContext>(opts =>
{
    opts.UseSqlite("Data Source=C:\\Users\\ravii\\source\\repos\\ElectionManagement\\ElectionManagement.WebAPI\\DB\\ElectionManagementSystem.db;", dbOpts => { });
});

builder.Services.AddScoped<IPartyRepository, PartyRepository>();
builder.Services.AddScoped<IConstituencyRepository, ConstituencyRepository>();
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
