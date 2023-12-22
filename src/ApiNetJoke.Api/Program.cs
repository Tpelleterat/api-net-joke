using ApiNetJoke.Api.Configuration;
using ApiNetJoke.Business;
using ApiNetJoke.Business.Interfaces;
using ApiNetJoke.Infrastructure;
using ApiNetJoke.Infrastructure.Interfaces;
using ApiNetJoke.Infrastructure.RefitApiInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Refit;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer((o) =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

// Official Joke API
builder.Services.AddOptions<OfficialJokeApiSettings>()
    .BindConfiguration("OfficialJokeApi")
    .ValidateDataAnnotations()
    .ValidateOnStart();
builder.Services.AddRefitClient<IOfficialJokeApi>()
    .ConfigureHttpClient((provider, httpClient) =>
    {
        var officialJokeApiSettings = provider.GetRequiredService<IOptions<OfficialJokeApiSettings>>().Value;

        httpClient.BaseAddress = new Uri(officialJokeApiSettings.Url);
    });

// Infrastructure
builder.Services.AddScoped<IJokeRequestService, JokeRequestService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
