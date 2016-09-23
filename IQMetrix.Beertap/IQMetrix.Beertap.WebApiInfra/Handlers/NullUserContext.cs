using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrix.Beertap.WebApiInfra.Handlers
{
    public class NullUserContext : IDisposable
    {
        public void Dispose() { }
    }
}
