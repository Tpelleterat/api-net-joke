using ApiNetJoke.Api.Configuration;
using ApiNetJoke.Business;
using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Infrastructure;
using ApiNetJoke.Infrastructure.Interfaces;
using ApiNetJoke.Infrastructure.RefitApiInterfaces;
using Microsoft.Extensions.Options;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Official Joke API
builder.Services.AddOptions<OfficialJokeApiSettings>()
    .BindConfiguration("OfficialJokeApi")
    .ValidateDataAnnotations()
    .ValidateOnStart();


builder.Services.AddRefitClient<IOfficialJokeApi>()
    .ConfigureHttpClient((provider, httpClient) =>
    {
        var configuration = provider.GetRequiredService<IOptions<OfficialJokeApiSettings>>().Value;

        httpClient.BaseAddress = new Uri(configuration.Url);
    });

// Infrastructure
builder.Services.AddScoped<IJobRequestService, JobRequestService>();

// Business
builder.Services.AddScoped<INumberOperationService, NumberOperationService>();
builder.Services.AddScoped<IJokeService, JokeService>();


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
