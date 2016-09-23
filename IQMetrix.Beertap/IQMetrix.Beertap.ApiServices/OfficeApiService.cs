using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Internal;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQMetrix.Beertap.ApiServices.Security;
using IQMetrix.Beertap.Model;
using IQ.Platform.Framework.WebApi;
using IQMetrix.Beertap.Data.Providers;

namespace IQMetrix.Beertap.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {

        readonly IApiUserProvider<BeertapApiUser> _userProvider;
        private readonly IOfficeProvider _officeProvider;
        public OfficeApiService(IApiUserProvider<BeertapApiUser> userProvider, IOfficeProvider officeProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException(nameof(userProvider));
            _userProvider = userProvider;
            _officeProvider = officeProvider;
        }


        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var office = _officeProvider.GetOffice(id);
            office.Kegs.ToList().ForEach(c => c.Office = null);
            return Task.FromResult(office);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            IEnumerable<Office> office = _officeProvider.GetOffices();
            office.ForEach(o => o.Kegs.ForEach(k => k.Office = null));
            return Task.FromResult(office);
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
