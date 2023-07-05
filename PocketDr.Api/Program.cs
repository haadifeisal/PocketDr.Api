using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PocketDr.Api;
using PocketDr.Api.DataTransferObjects.Configuration;
using PocketDr.Api.Repositories.ChatGPT;
using PocketDr.Api.Repositories.ChatGPT.Interfaces;
using PocketDr.Api.Repositories.PocketDr;
using PocketDr.Api.Repositories.PocketDr.Interfaces;
using PocketDr.Api.Services;
using PocketDr.Api.Services.Interfaces;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppSettings>(builder.Configuration);
var provider = builder.Services.BuildServiceProvider();

var appSettings = provider.GetRequiredService<IOptions<AppSettings>>();

var allowedOrigins = nameof(appSettings.Value.AllowedOrigins);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapConfiguration());
});
var mapper = mappingConfig.CreateMapper();

var dbUsername = string.IsNullOrEmpty(builder.Configuration["DbUsername"]) ? appSettings.Value.DbUsername : builder.Configuration["DbUsername"];
var dbPassword = string.IsNullOrEmpty(builder.Configuration["DbPassword"]) ? appSettings.Value.DbPassword : builder.Configuration["DbPassword"];
var dbName = string.IsNullOrEmpty(builder.Configuration["DbName"]) ? appSettings.Value.DbName : builder.Configuration["DbName"];
var dbHostname = appSettings.Value.DbHostname;
var dbPort = appSettings.Value.DbPort;

var con = $"Host={dbHostname};Port={dbPort};Database={dbName};Username={dbUsername};Password={dbPassword}";

Console.WriteLine($"\n\nConnectionString: {con}\n\n");

builder.Services.AddDbContext<PocketDrContext>(options => options.UseNpgsql(con));
builder.Services.AddSingleton(mapper);
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IChatGPTRepository, ChatGPTRepository>();
builder.Services.AddScoped<IPocketDrRepository, PocketDrRepository>();
builder.Services.AddScoped<IPocketDrService, PocketDrService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrigins, builder =>
    {
        builder.WithOrigins(appSettings.Value.AllowedOrigins) // .WithOrigins(this.Configuration.GetSection("AllowedOrigins").Get<string[]>()).WithHeaders(...)
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<PocketDrContext>();

context.Database.Migrate();
SeedDB.SeedData(context);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowedOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
