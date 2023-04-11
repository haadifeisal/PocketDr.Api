using Microsoft.Extensions.Options;
using PocketDr.Api;
using PocketDr.Api.Repositories.ChatGPT;
using PocketDr.Api.Repositories.ChatGPT.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<AppSettings>(builder.Configuration);
var provider = builder.Services.BuildServiceProvider();
var appSettings = provider.GetRequiredService<IOptions<AppSettings>>();

var allowedOrigins = nameof(appSettings.Value.AllowedOrigins);

builder.Services.AddControllers();

builder.Services.AddScoped<IChatGPTRepository, ChatGPTRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(allowedOrigins, builder =>
    {
        builder.WithOrigins(appSettings.Value.AllowedOrigins) // .WithOrigins(this.Configuration.GetSection("AllowedOrigins").Get<string[]>()).WithHeaders(...)
            .WithHeaders("accept", "content-type", "oigin", "authorization")
            .AllowAnyMethod();
    });
});

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
