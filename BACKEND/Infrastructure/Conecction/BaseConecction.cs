using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Conecction
{
    public class BaseConecction
    {
        protected static IConfiguration? _dapperConfiguration;

        public static IConfiguration DapperConfiguration
        {
            get { return _dapperConfiguration; }
        }

        protected BaseConecction(IConfiguration _configuration)
        {
            _dapperConfiguration = new ConfigurationBuilder().AddConfiguration(_configuration).Build();
        }
    }
}
