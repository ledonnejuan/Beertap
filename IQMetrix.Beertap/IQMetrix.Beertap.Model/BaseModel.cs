using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrix.Beertap.Model
{
    /// <summary>
    /// Base Model
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Identity
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
