using Microsoft.Extensions.DependencyInjection;
using ProjectX.Server.Interfaces;
using ProjectX.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectX.Server.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MyAllowSpecificOrigins",
                        builder => {
                            builder.WithOrigins("https://localhost:44350")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                        });
            });
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IFishRepository, FishRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IBoatRepository, BoatRepository>();
            services.AddScoped<IBoatLoadRepository, BoatLoadRepository>();
            services.AddScoped<IBoatLoadDetailsRepository, BoatLoadDetailsRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IPurchaseDetailsRepository, PurchaseDetailsRepository>();
            services.AddScoped<IPurchaseBatchRepository, PurchaseBatchRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
        }
    }
}
