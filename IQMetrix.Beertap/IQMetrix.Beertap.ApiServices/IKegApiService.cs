using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.ApiServices
{
    public interface IKegApiService : 
        IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>,
        ICreateAResourceAsync<Keg, int>,
        IUpdateAResourceAsync<Keg, int>,
        IDeleteResourceAsync<Keg, int>
    {
    }
}
