using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQMetrix.Beertap.ApiServices.Security;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.ApiServices
{
    public class BeerMugApiService : IBeerMugApiService
    {
        readonly IApiUserProvider<BeertapApiUser> _userProvider;
        public BeerMugApiService(IApiUserProvider<BeertapApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException(nameof(userProvider));
            _userProvider = userProvider;
        }

        public Task<BeerMug> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var bm = new BeerMug() { Id = 1, Capacity = 300 };
            return Task.FromResult(bm);
        }

        public Task<IEnumerable<BeerMug>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
