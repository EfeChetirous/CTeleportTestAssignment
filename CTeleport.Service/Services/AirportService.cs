using CTeleport.Core.Cache;
using CTeleport.Model.ApiResultModel;
using CTeleport.Model.Models;
using CTeleport.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTeleport.Service.Services
{
    public class AirportService : IAirportService
    {
        private readonly ICacheManager<AirportInfoModel> _cacheManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AirportService> _logger;
        public AirportService(ICacheManager<AirportInfoModel> cacheManager, IConfiguration configuration, ILogger<AirportService> logger)
        {
            _cacheManager = cacheManager;
            _configuration = configuration;
            _logger = logger;
        }
        
        public async Task<AirportInfoModel> GetAirportInfoAsync(string airportCode)
        {
            if (_cacheManager.Get<AirportInfoModel>(airportCode) != null)
            {
                return await _cacheManager.GetAsync<AirportInfoModel>(airportCode);
            }
            AirportInfoModel airportInfo = new AirportInfoModel();
            var response = string.Empty;
            string teleportDevUrl = _configuration["AppSettings:TelePortDevUrl"].ToString();
            string endPoint = $"{teleportDevUrl}{airportCode.ToUpper(new CultureInfo("en-US", false))}";
            _logger.LogInformation($"Get Endpoint : {endPoint}");
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(endPoint);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                    airportInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<AirportInfoModel>(response);
                    _logger.LogInformation($"response : {airportInfo}");
                    //add to cache
                    if (airportInfo != null)
                    {
                        await _cacheManager.AddAsync<AirportInfoModel>(airportCode, airportInfo);
                    }
                }
                else
                {
                    throw new Exception("An error is occured while fetching airport info. Please check airport IATA code.");
                }
            }
            return airportInfo;
        }
    }
}
