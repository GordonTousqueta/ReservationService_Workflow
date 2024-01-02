
using Microsoft.EntityFrameworkCore;
using ReservationService.Datas.Context;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

//Lien pour la bdd . Le context de bdd est dans applicationDbContext. On utilise UseSqlite, et on entre la connectionstring
//La connectionString est définie dans appsetting.Development.Json
var connectionString = configuration.GetConnectionString("BaseConnectionString");

builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllers();

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
