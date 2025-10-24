using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PraticaApi.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProdutoContext>(options =>
{
    options.UseMySql
    (
        builder.Configuration.GetConnectionString("ConecaoPadrao"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConecaoPadrao"))
        );
});

// Add services to the container.

builder.Services.AddControllers();
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
