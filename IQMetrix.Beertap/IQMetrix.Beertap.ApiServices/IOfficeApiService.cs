using IQMetrix.Beertap.Model;
using IQ.Platform.Framework.WebApi;

namespace IQMetrix.Beertap.ApiServices
{
    public interface IOfficeApiService :
        IGetAResourceAsync<Office, int>,
        IGetManyOfAResourceAsync<Office, int>,
        ICreateAResourceAsync<Office, int>,
        IUpdateAResourceAsync<Office, int>,
        IDeleteResourceAsync<Office, int>
    {
    }
}
