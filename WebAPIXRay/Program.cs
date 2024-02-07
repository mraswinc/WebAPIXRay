using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Contrib.Extensions.AWSXRay.Resources;
using OpenTelemetry.Contrib.Extensions.AWSXRay.Trace;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

//// Add OpenTelemetry
//var tracerProvider = Sdk.CreateTracerProviderBuilder()
//                        .AddSource("WebAPIXray")
//                        .AddXRayTraceId() // for generating AWS X-Ray compliant trace IDs
//                        .AddOtlpExporter() // default address localhost:4317
//                        .AddAspNetCoreInstrumentation()
//                        .SetResourceBuilder(ResourceBuilder
//                            .CreateDefault()
//                            .AddDetector(new AWSEC2ResourceDetector()))
//                        .Build();

//var meterProvider = Sdk.CreateMeterProviderBuilder()
//                        .AddMeter("adot")
//                        .AddOtlpExporter()
//                        .Build();

//Sdk.SetDefaultTextMapPropagator(new AWSXRayPropagator()); // configure AWS X-Ray propagator

// Add services to the container.
builder.Services.AddOpenTelemetry()
    .WithTracing(builder => builder
        .AddAspNetCoreInstrumentation()
        .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("AWSOtelWebAPI"))
        .AddXRayTraceId() // for generating AWS X-Ray compliant trace IDs
        .AddOtlpExporter()
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddSqlClientInstrumentation()
        .AddAWSInstrumentation());

Sdk.SetDefaultTextMapPropagator(new AWSXRayPropagator());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
