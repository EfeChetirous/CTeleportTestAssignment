using CTeleport.Core.Cache;
using CTeleport.Model.Models;
using CTeleport.Service.Interfaces;
using CTeleport.Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration? configuration = null)
        {
            serviceCollection.AddSingleton<ICacheManager<AirportInfoModel>, CacheManager<AirportInfoModel>>();
            serviceCollection.AddTransient<IAirportService, AirportService>();
            serviceCollection.AddTransient<IDistanceCalculationService, DistanceCalculationService>();
            
        }
    }
}
