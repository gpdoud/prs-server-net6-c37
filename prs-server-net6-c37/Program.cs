using Microsoft.EntityFrameworkCore;

using prs_server_net6_c37.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PrsContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("DevDb"));
});
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
