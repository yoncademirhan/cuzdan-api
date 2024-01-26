using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAPI.EntityFramework;
using WebAPI.EntityFramework.Repositories;
using WebAPI.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// singleton - transient - scoped
// singleton -> uygulama boyunca tek bir instance oluþturulur
// transient -> her çaðrýldýðýnda yeni bir instance oluþturulur
// scoped -> her request için bir instance oluþturulur

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseInMemoryDatabase("context");
});

builder.Services.AddScoped<IWalletRepository, WalletRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
