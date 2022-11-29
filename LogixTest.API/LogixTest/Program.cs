using AutoMapper;
using LogixTest.Extensions;
using LogixTest.Infrastructure;
using LogixTest.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LogixTestApi", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement(){
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
            new List<string>()
            }
        });
});

builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddSqlServer<DataContext>(connectionString);

builder.Services.AddScoped<IUserProfileService, UserProfileService>();

builder.Services.AddInfratructure();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowPath", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowCredentials();
        builder.WithOrigins("http://localhost:4200"); //for test propose
    });
});

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "LogixTestApi");
    });
}

app.UseCors("AllowPath");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
