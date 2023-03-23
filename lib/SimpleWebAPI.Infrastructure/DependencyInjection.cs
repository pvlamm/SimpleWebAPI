namespace SimpleWebAPI.Infrastructure
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using SimpleWebAPI.Application.Common.Interfaces;
    using SimpleWebAPI.Infrastructure.Cache;
    using SimpleWebAPI.Infrastructure.Persistance;
    using SimpleWebAPI.Infrastructure.Services;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options
                .UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging(true)
                .UseInMemoryDatabase("cleanDb"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            services.AddTransient<IPersonService, PersonService>();
            services.AddSingleton<IPersonMemoryCache, PersonMemoryCache>();
            return services;
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            //builder.AddConsole();
        });
    }
}