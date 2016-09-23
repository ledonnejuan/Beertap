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
    /// 
    /// </summary>
    public class GetBeer : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int KegId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Amount { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public Keg Keg { get; set; }
    }
}
