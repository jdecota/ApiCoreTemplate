
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using zo_organized.ItemSingular.Domain.Aggregates;
using zo_organized.ItemSingular.Domain.Commands;
using zo_organized.ItemSingular.Domain.Repositories;
using zo_organized.ItemSingular.Infrastructure.CommandHandlers;
using zo_organized.ItemSingular.Infrastructure.Repositories;
using zo_organized.Shared;
using zo_organized.Shared.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(ISqlDataAccess<>), typeof(SqlDataAccess<>));

builder.Services.AddScoped(typeof(IItemSingularRepository<ItemSingularAggregate>), typeof(ItemSingularRespository));
builder.Services.AddScoped<IItemSingularCommands<ItemSingularAggregate>, ItemSingularCommands>();



//builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
//builder.Services.AddSingleton<IQuery, Query>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
