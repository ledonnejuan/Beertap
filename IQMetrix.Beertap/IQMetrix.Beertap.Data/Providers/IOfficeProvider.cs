using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.Data.Providers
{
    public interface IOfficeProvider
    {
        /// <summary>
        /// Get Office by Id
        /// </summary>
        /// <param name="id">Office id</param>
        /// <returns>IQMetrix.Beertap.Model.Office</returns>
        Office GetOffice(int id);

        /// <summary>
        /// Get All Offices
        /// </summary>
        /// <returns>List of IQMetrix.Beertap.Model.Office</returns>
        List<Office> GetOffices();

        /// <summary>
        /// Update Office
        /// </summary>
        /// <param name="office">IQMetrix.Beertap.Model.Office</param>
        /// <returns>bool</returns>
        bool UpdateOffice(Office office);

        /// <summary>
        /// Create Office
        /// </summary>
        /// <param name="office">Office</param>
        /// <returns>IQMetrix.Beertap.Model.Office</returns>
        Office CreateOffice(Office office);
    }
}