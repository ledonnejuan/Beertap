using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IQMetrix.Beertap.Model
{
    /// <summary>
    /// Beer Mug
    /// </summary>
    public class BeerMug : BaseModel, IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Capacity
        /// </summary>
        public int Capacity { get; set; }
    }
}
