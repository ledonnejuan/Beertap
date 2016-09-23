using System.Collections.Generic;
using System.Web.Script.Serialization;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using Newtonsoft.Json;

namespace IQMetrix.Beertap.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class Office : BaseModel, IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Name for the SampleResource
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description for the SampleResource
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Kegs
        /// </summary>
        public ICollection<Keg> Kegs { get; set; }
    }
}
