using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("WeatherV1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Hava durumu API",
        Description = "public hava durumu API dır",
        Contact = new OpenApiContact
        {
            Name = "Murat",
            Email = "murat@murat.com"
        }
    });
    var xmlFile=$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath=Path.Combine(AppContext.BaseDirectory, xmlFile);
    option.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("WeatherV1/swagger.json", "Weather API");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
