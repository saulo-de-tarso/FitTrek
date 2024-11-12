using FitTrek.API.Extensions;
using FitTrek.API.Middlewares;
using FitTrek.Application.Extensions;
using FitTrek.Domain.Entities;
using FitTrek.Infrastructure.Extensions;
using FitTrek.Infrastructure.Seeders;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);



var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<INutritionistSeeder>();

await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("api/identity").MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
