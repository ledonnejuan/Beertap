using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQMetrix.Beertap.ApiServices.Security;
using IQMetrix.Beertap.Data.Providers;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.ApiServices
{
    public class KegApiService : IKegApiService
    {
        readonly IApiUserProvider<BeertapApiUser> _userProvider;
        private readonly IKegProvider _kegProvider;
        public KegApiService(IApiUserProvider<BeertapApiUser> userProvider, IKegProvider kegProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException(nameof(userProvider));
            _userProvider = userProvider;
            _kegProvider = kegProvider;
        }
        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(() => context.CreateHttpResponseException<Keg>("The placeId must be supplied in the URI", HttpStatusCode.BadRequest));
            var keg = _kegProvider.GetKeg(id);
            var k = new Keg()
            {
                Id = keg.Id,
                Capacity = keg.Capacity,
                Content = keg.Content,
                KegState = keg.KegState,
                OfficeId = keg.OfficeId,
                Remaining = keg.Remaining
            };
            return Task.FromResult(k);
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(() => context.CreateHttpResponseException<Keg>("The placeId must be supplied in the URI", HttpStatusCode.BadRequest));
            IEnumerable<Keg> keg = _kegProvider.GetKegByOfficeId(officeId);
            
            var kegs = from k in keg
                select new Keg()
                {
                    Id = k.Id,
                    Capacity = k.Capacity,
                    Content = k.Content,
                    KegState = k.KegState,
                    OfficeId = k.OfficeId,
                    Remaining = k.Remaining
                };

            return Task.FromResult(kegs);
        }

        public Task<ResourceCreationResult<Keg, int>> CreateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Keg> UpdateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Keg, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
