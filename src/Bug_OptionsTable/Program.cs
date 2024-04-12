using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<ConfigOptions>().Bind(builder.Configuration.GetSection(ConfigOptions.SectionName));
builder.Services.AddOptions<ConfigOptions>().Bind(builder.Configuration.GetSection(ConfigOptions.SectionName));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/config", (IOptions<ConfigOptions> options) => options.Value)
.WithName("GetConfig")
.WithOpenApi();

app.Run();


public class ConfigOptions
{
    public const string SectionName = "Config";
    
    public int Id { get; init; }
    public string[] List { get; init; }
}

public partial class Program {}