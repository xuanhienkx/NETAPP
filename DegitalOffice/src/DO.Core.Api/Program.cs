
using AutoMapper;
using DO.Common;
using DO.Common.Contract;
using DO.Common.Domain;
using DO.Common.Domain.Interfaces;
using DO.Common.Std.Extensions;
using DO.Core.Api.Configurations;
using MediatR;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using WebApiContrib.Core.Formatter.Protobuf;

var process = Process.GetCurrentProcess();
Console.Title = $"API service - PID: {process.Id}";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logConfig = builder.Configuration.GetSection("Logging");
builder.Services.AddLogging(builder =>
{
    builder.ClearProviders();
    builder.AddConsole();
    builder.AddFile(logConfig);
    builder.SetMinimumLevel(LogLevel.Debug);

});
// add distributed cached
builder.Services.AddDistributedCache(builder.Configuration);

// add localizer
builder.Services.AddLocalizer(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddSecurity(builder.Configuration);

builder.Services.AddControllers()
    .AddProtobufFormatters() 
    .AddNewtonsoftJson(options =>
      {
          options.UseCamelCasing(false);
          options.SerializerSettings.Converters.Add(new StringEnumConverter());
          options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
      });
builder.Services.AddLocalization();
// Add MediaR   
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddSignalR();
// Add auto mapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Register all commponents
Executor.Try(
    () => RegisterAllComponents(builder.Services),
    exception => Debug.WriteLine($"[REGISTER] FAILED: {exception}"),
    true);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "DSoft API v1.1");
        // s.ShowRequestHeaders();

    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void RegisterAllComponents(IServiceCollection services)
{
    Register(() =>
    {
        services.AddSingleton<IStringLocalizerFactory, LocalizationFactory>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // register all repositories
        DO.Core.Service.DependencyInjectorBootstrapper.Register(services);

        // register VSD gateway service
        DO.Market.Service.DependencyInjectorBootstrapper.Register(services);

        // register ApI core services
        services.AddScoped<IDomainDataHandler, DomainDataHandler>();
        services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

        services.AddScoped<IMediator, Mediator>();
        // services.AddTransient<SingleInstanceFactory>(sp => sp.GetService);     

        services.AddSingleton<INotificationPublisher, NotificationPublisher>();

        //domain event
        services.AddScoped<IDomainEventHandler<NotificationMessage>, DomainEventNotificationHandler>();
    });
}

static void Register(Action register)
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();

    register();

    stopWatch.Stop();
    Debug.WriteLine("[REGISTER] Finished in {0} ms", stopWatch.ElapsedMilliseconds);
}

