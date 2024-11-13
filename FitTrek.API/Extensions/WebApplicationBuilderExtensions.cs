using FitTrek.API.Middlewares;
using FitTrek.Application.Clients.Enums;
using FitTrek.Domain.Enums;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Serilog;

namespace FitTrek.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {

        builder.Services.AddAuthentication();
        builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            });


        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                    },
                    []
                }
            });

            
                                               
            c.MapType<Gender>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = new List<IOpenApiAny>
                {
                    new OpenApiString("Male"),
                    new OpenApiString("Female"),
                    new OpenApiString("Other")   
                },
                    Example = new OpenApiString("Male")
            });

            
            c.MapType<SubscriptionPlan>(() => new OpenApiSchema
            {
                Type = "string",  
                Enum = new List<IOpenApiAny>
            {
                new OpenApiString("Silver"),  
                new OpenApiString("Gold"),  
                new OpenApiString("Platinum")   
            },
                Example = new OpenApiString("Silver")  
            });

            c.MapType<NutritionistSortBy>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = new List<IOpenApiAny>
            {
                new OpenApiString("FirstName"),
                new OpenApiString("CurrentMonthlyRevenue")
            }
            });

            c.MapType<ClientSortBy>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = new List<IOpenApiAny>
            {
                new OpenApiString("FirstName"),
                new OpenApiString("WeightInKg"),
                new OpenApiString("HeightInCm"),
            }
            });

            c.MapType<SortDirection>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = new List<IOpenApiAny>
            {
                new OpenApiString("Ascending"),
                new OpenApiString("Descending")
            }
            });
        });

        builder.Services.AddTransient<ErrorHandlingMiddleware>();
        
        builder.Services.AddEndpointsApiExplorer();

        builder.Host.UseSerilog((context, configuration) =>
            configuration.ReadFrom.Configuration(context.Configuration)
        );


    }
}

