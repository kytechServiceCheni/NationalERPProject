using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Nation.Services;
using National;
using National.Repository.Entity;
using National.Services;
using National.Web.Api;
using National.WebApi.Authentication;
using National.Domain.Logic.Utilitys;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter())); ;
builder.Services.AddControllers() ;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<JsonOptions>(options =>
    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter()));
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
var connectionString = builder.Configuration.GetConnectionString("DBConnection");

builder.Services.AddDbContext<NationalContext>(options => options.UseNpgsql(connectionString));
RegisterServices.Services(builder);

var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddResponseCaching();
builder.Services.AddResponseCompression();
var app = builder.Build();
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); 
app.UseResponseCaching();

//p.UseAuthorization();
app.UseAuthorization();

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
//app.UseMiddleware<ValidateToken>();
app.MapControllers();

app.Run();
