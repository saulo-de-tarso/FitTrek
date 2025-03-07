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
var seeder = scope.ServiceProvider.GetRequiredService<IFitTrekSeeder>();

await seeder.Seed();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseSerilogRequestLogging();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGroup("api/identity").
    WithTags("Identity").
    MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

app.Run();
