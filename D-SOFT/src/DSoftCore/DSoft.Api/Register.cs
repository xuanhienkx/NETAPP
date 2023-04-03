using DSoft.Api.Utils;
using DSoft.Common;
using DSoft.Common.Settings;
using DSoft.Common.Shared.Base;
using DSoft.MarketParser;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DSoft.Api;

static class Register
{
    internal static void AddComponents(this IServiceCollection services, IConfigurationRoot config, ApplicationSettings applicationSettings)
    {
        services.AddSingleton<IConfigurationRoot>(config);
        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
        });
        services.AddVersionedApiExplorer(
                       options =>
                       {
                           // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                           // note: the specified format code will format the version as "'v'major[.minor][-status]"
                           options.GroupNameFormat = "'v'VVV";

                           // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                           // can also be used to control the format of the API version in route templates
                           options.SubstituteApiVersionInUrl = true;
                       });
        // add logging 
        var logConfig = config.GetSection("Logging");
        services.AddLogging(builder =>
        {
            // builder.ClearProviders();
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Debug);

        });

        services.AddCors(options => options.AddPolicy(ProviderConstants.CorsPolicy, builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader();

            if (applicationSettings.EnableSignalR)
                builder.WithOrigins(applicationSettings.ClientUrl).AllowCredentials();
            else
                builder.AllowAnyOrigin();
        }));

        services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.UseCamelCasing(false);
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

        ComponentRegister.Register(services, config);

        // register all components from other resources
        MarketParserRegister.Register(services, config);

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
        {
            options.Authority = config["applicationSettings:Authority"];
            options.RequireHttpsMetadata = false;
            options.Audience = "dsoft_api";
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            };
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query[ProviderConstants.MessageAccessToken];

                    // If the request is for our hub...
                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments(ProviderConstants.WebSocketSegment)))
                    {
                        // Read the token out of the query string
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };
            //Fix SSL
            options.BackchannelHttpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = delegate { return true; }
            };
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("ApiScope", builder =>
            {
                builder.RequireAuthenticatedUser();
                builder.RequireClaim("scope", "DSoftApi");
            });
        });      
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        // add multipart guard
         services.Configure<FormOptions>(options =>
        {
            // Set the limit to 50 MB

            if (long.TryParse(config["applicationSettings:dataFileSizeLimit"], out long bodyLengthLimit))
                bodyLengthLimit = 52428800;
           
            options.MultipartBodyLengthLimit = bodyLengthLimit;
        });
        // mediatR
        services.AddMediatR(typeof(Register).Assembly);
        services.AddConnections();
        //Health check
        var dbSettings = config.GetSection(ProviderConstants.DomainDatabaseSettings).Get<DatabaseSettings>();

        services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddMongoHealthCheck("Mongo", new MongoClient(dbSettings.ConnectionString).GetDatabase("admin"));
        // Note this 
        services.AddHealthChecksUI(opt =>
        {
            opt.SetEvaluationTimeInSeconds(15); //time in seconds between check
            opt.MaximumHistoryEntriesPerEndpoint(60); //maximum history of checks
            opt.SetApiMaxActiveRequests(1); //api requests concurrency

            opt.AddHealthCheckEndpoint("DSoft API", "/hc"); //map health check api
        }).AddInMemoryStorage();
    }

    internal static void AddSwagger(this IServiceCollection services, ApplicationSettings settings)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "DSoft.API V1", Version = "v1" });
            c.SwaggerDoc("v2", new OpenApiInfo { Title = "DSoft.API V2", Version = "v2" });

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri($"{settings.Authority}/connect/authorize"),
                        TokenUrl = new Uri($"{settings.Authority}/connect/token"),
                        Scopes = new Dictionary<string, string>()
                            {
                                {"dsoft_api", "dsoft_api"},
                            }
                    }
                }
            });
            c.OperationFilter<AuthorizeCheckOperationFilter>();

        });

    }
    internal static void UseLocalization(this IApplicationBuilder app)
    {
        var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(localizationOptions.Value);
    }
}