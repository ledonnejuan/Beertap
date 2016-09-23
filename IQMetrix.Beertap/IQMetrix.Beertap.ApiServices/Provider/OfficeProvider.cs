using IQMetrix.Beertap.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQMetrix.Beertap.ApiServices.Provider
{
    public class OfficeProvider : IOfficeProvider
    {
        private static List<Office> _offices;

        public OfficeProvider()
        {
            if (_offices == null)
            {
                //initialize data
                _offices = new List<Office>();
                _offices.Add(new Office() { Id = 1, Name = "Vancouver", Location = "Vancouver, Canada" });
                _offices.Add(new Office() { Id = 2, Name = "Regina", Location = "Regina, Canada" });
                _offices.Add(new Office() { Id = 3, Name = "Winnipeg", Location = "Winnipeg, Canada" });
                _offices.Add(new Office() { Id = 4, Name = "Davidson", Location = "North Carolina" });
                _offices.Add(new Office() { Id = 5, Name = "Manila", Location = "Manila, Philippines" });
                _offices.Add(new Office() { Id = 6, Name = "Sydney", Location = "Sydney, Australia" });
            }
        }
        public Office GetOffice(int id)
        {
            return _offices.Find(c => c.Id.Equals(id));
        }

        public List<Office> GetOffices()
        {
            return _offices;
        }

        public bool UpdateOffice(Office office)
        {
            throw new NotImplementedException();
        }

        public Office CreateOffice(Office office)
        {
            throw new NotImplementedException();
        }
    }
}
