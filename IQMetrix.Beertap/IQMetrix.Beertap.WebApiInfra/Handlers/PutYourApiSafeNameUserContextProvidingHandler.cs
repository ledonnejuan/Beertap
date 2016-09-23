using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQMetrix.Beertap.ApiServices.Security;

namespace IQMetrix.Beertap.WebApiInfra.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<BeertapApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<BeertapApiUser> apiUserInRequestStore)
            : base(new BeertapUserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<BeertapApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<BeertapApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}
