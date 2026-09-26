using Microsoft.EntityFrameworkCore;
using Blog.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<BlogDbContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("BlogDb")));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
