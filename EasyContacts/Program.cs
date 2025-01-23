using EasyContacts;
using EasyContacts.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EasyContactsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EasyContactsContext") 
    ?? throw new InvalidOperationException("Connection string 'EasyContactsContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapContactEndpoints();

app.Run();
