using CLINICAL.Api.Extensions.Middleware;
using CLINICAL.Infrastructure.Extensions;
using CLINICAL.UseCase.Extensions;
using CLINICAL.Persistence.Extensions;
using CLINICAL.Api.Authentication;

var builder = WebApplication.CreateBuilder(args);

var Cors = "Cors";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInjectionApplication();
builder.Services.AddInjectionPersistence();
builder.Services.AddInjectionInfraestructure(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors,
        builder =>
        {
            builder.WithOrigins("*");
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCors(Cors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

app.Run();
