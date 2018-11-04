using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reminder.Domain.Interfaces.AppService;
using Reminder.Application.Service;
using Reminder.Domain.Interfaces.Repository;
using Reminder.Infra.Data.Repository;
using Reminder.Infra.Data;
using AutoMapper;

namespace Reminder.Infra.CrossCutting
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration) {

            services.AddAutoMapper(o => o.AddProfile(new AutoMapperProfile()));

            // AppService
            services.AddScoped<IReminderAppService, ReminderAppService>();

            // Repository
            services.AddScoped<IReminderRepository, ReminderRepository>();

            services.Configure<ContextSettings>(o => {
                o.ConnectionString = configuration.GetSection("MongoConnection:ConnectionString").Value;
                o.Database = configuration.GetSection("MongoConnection:Database").Value;
            });
        }
    }
}
