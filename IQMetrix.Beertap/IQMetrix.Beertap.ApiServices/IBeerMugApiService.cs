using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.ApiServices
{
    public interface IBeerMugApiService :
        IGetAResourceAsync<BeerMug, int>,
        IGetManyOfAResourceAsync<BeerMug, int>
    {
    }
}
