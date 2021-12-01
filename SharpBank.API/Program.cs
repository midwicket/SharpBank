using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharpBank.API;
using SharpBank.API.Services.ImplementationDB;
using SharpBank.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SharpDBCS")));

builder.Services.AddControllers().AddJsonOptions(opt=>opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IBankService, BankService>();
//builder.Services.AddScoped<IAccountService, BankService>();
//builder.Services.AddScoped<ITransactionService, BankService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
