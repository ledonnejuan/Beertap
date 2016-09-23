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
    public enum OfficeState
    {
        /// <summary>
        /// A place exists, and is ready to accept people.
        /// POST /Places(123)/Persons
        /// </summary>
        Created,
        /// <summary>
        /// Place is full. Can't take any more people.
        /// DELETE /Places(123)/Persons
        /// </summary>
        Full
    }
}
