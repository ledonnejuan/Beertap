using System.Web.Http;
using IQMetrix.Beertap.WebApi.Hypermedia;
//using IQMetrix.Beertap.WebApi.Infrastructure;
using IQMetrix.Beertap.WebApiInfra;

namespace IQMetrix.Beertap.WebApi
{

    public class HttpServerFactory
    {
        public HttpServer Create()
        {
            return new HttpServer(GetHttpConfiguration());
        }

        private static HttpConfiguration GetHttpConfiguration()
        {
            var config = new HttpConfiguration();
            BootStrapper.Initialize(config, typeof(OfficeSpec).Assembly, typeof(OfficeSpec).Assembly);
            return config;
        }
    }
}