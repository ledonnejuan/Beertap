using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Security;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace IQMetrix.Beertap.WebApiInfra.Security
{
    //TODO: comment out below class to turn on SSO based authentication
    public class AlwaysAuthenticateRequestAuthenticator : IRequestAuthenticator<UserAuthData>
    {
        public UserAuthData Verify(HttpRequestMessage request)
        {
            return new UserAuthData("null token");
        }
    }
}
