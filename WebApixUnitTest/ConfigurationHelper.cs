using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApixUnitTest
{
    public static class ConfigurationHelper
    {
        private readonly static IConfiguration _configuration;

        static ConfigurationHelper()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();


        }

        private static string? _baseUrl;


        public static IConfiguration Configuration()
        {
            var path = Directory.GetCurrentDirectory();
            var cnx = new ConfigurationBuilder()
             .SetBasePath(path)
             .AddJsonFile("appsettings.json")
             .AddEnvironmentVariables()
             .Build();
            return cnx;
        }

        //public static IConfigurationRoot GetIConfigurationRoot()
        //{
        //    return new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddEnvironmentVariables()
        //        .Build();
        //}

        public static string GetBaseUrl()
        {
            if (_baseUrl == null)
            {
                _baseUrl = _configuration["ConnectionStrings:ConexionSvr_Default"];
                ArgumentNullException.ThrowIfNull(_baseUrl);
                _baseUrl = _baseUrl.TrimEnd('/');
            }
            return _baseUrl;
        }
    }
}
