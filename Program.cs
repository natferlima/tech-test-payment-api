using Microsoft.EntityFrameworkCore;
using tech_test_payment_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PaymentAPIContext>
    (options => options.UseMySql(
        "server=localhost;user=root;password=Nat123456*;database=PaymentAPI",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")
    ));

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
