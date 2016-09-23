using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrix.Beertap.Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStatefulOffice
    {
        /// <summary>
        /// 
        /// </summary>
        OfficeState OfficeState { get; set; }
    }
}
