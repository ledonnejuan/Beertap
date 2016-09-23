using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace IQMetrix.Beertap.Model
{
    /// <summary>
    /// Keg
    /// </summary>
    public class Keg : BaseModel, IStatefulResource<KegState>, IIdentifiable<int>
    {
        /// <summary>
        /// Capacity
        /// </summary>
        public int Capacity { get; set; }
        /// <summary>
        /// Remaining
        /// </summary>
        public int Remaining { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Office Id
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// Keg State
        /// </summary>
        public KegState KegState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("OfficeId")]
        public Office Office { get; set; }
    }
}
