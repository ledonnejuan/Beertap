using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQMetrix.Beertap.ApiServices.Security;
using IQMetrix.Beertap.Data.Providers;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.ApiServices
{
    public class ReplaceKegApiService : IReplaceKegApiService
    {
        readonly IApiUserProvider<BeertapApiUser> _userProvider;
        private readonly IKegProvider _kegProvider;
        public ReplaceKegApiService(IApiUserProvider<BeertapApiUser> userProvider, IKegProvider kegProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException(nameof(userProvider));
            _userProvider = userProvider;
            _kegProvider = kegProvider;
        }
        public Task<ReplaceKeg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(() => context.CreateHttpResponseException<Office>("The placeId must be supplied in the URI", HttpStatusCode.BadRequest));
            var kegId = context.UriParameters.GetByName<int>("Id").EnsureValue(() => context.CreateHttpResponseException<Keg>("The placeId must be supplied in the URI", HttpStatusCode.BadRequest));
            _kegProvider.ReplaceKeg(officeId, kegId);
            return Task.FromResult(resource);
        }
    }
}
