using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Server;
using Server.Data;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(DbContextOptionsBuilder => DbContextOptionsBuilder.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(SwaggerOptions =>
{
    SwaggerOptions.SwaggerDoc("part_1", new OpenApiInfo
    {
        Title = "Angular Asp Web Api", Version = "v1"
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(SwaggerOptions =>
{
    SwaggerOptions.DocumentTitle = "Angular Asp Api";
    SwaggerOptions.SwaggerEndpoint("swagger/part_1/swagger.json","Web Api Serv with Post model");
    SwaggerOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.MapPostsEndpoints();



app.Run();

