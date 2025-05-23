﻿using API.Services;
using AspNetCoreRateLimit;
using Core.Interfaces;
using Core.Interfases;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWork;
using System.Reflection;

namespace API.Extensions;
public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration) =>
        services.AddCors(options =>
        {
        var policyName = configuration["CorsSettings:PolicyName"];
            string[] origins = configuration.GetSection("CorsSettings:Origins").Get<string[]>();
            string[] verbs = configuration.GetSection("CorsSettings:Methods").Get<string[]>();

            options.AddPolicy(policyName, builder =>
                builder.WithOrigins(origins)
                    .WithMethods(verbs)
                    .AllowAnyHeader());
        });

    public static void AddAplicacionServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddAutoMapper(Assembly.GetEntryAssembly());
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<ISpecialityRepository, SpecialityRepository>();
        services.AddScoped<AppointmentService>();
        services.AddScoped<StaffService>();
        services.AddScoped<DoctorService>();
        services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
    }

    public static void ConfigureRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        var endpoint = configuration["RateLimit:Endpoint"];
        var period = configuration["RateLimit:Period"];
        var limit = double.Parse(configuration["RateLimit:Limit"]);
        var realIpHeader = configuration["RateLimit:RealIpHeader"];
        var httpStatusCode = int.Parse(configuration["RateLimit:HttpStatusCode"]);

        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();

        services.Configure<IpRateLimitOptions>(options =>
        {
            options.EnableEndpointRateLimiting = true;
            options.StackBlockedRequests = false;
            options.HttpStatusCode = httpStatusCode;
            options.RealIpHeader = realIpHeader;
            options.GeneralRules = new List<RateLimitRule>
            {
                new RateLimitRule
                {
                    Endpoint=endpoint,
                    Period=period,
                    Limit=limit
                }
            };
        });
    }
}
