using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.Data.Providers
{
    public class OfficeProvider : IOfficeProvider
    {
        private readonly IBeertapRepository<Office> _officeRepository;

        public OfficeProvider(IBeertapRepository<Office> officeRepository)
        {
            _officeRepository = officeRepository;
        }
        public Office GetOffice(int id)
        {
            return _officeRepository.FindBy(c => c.Id == id).Include(c => c.Kegs).FirstOrDefault();
        }

        public List<Office> GetOffices()
        {
            return _officeRepository.GetAll().Include(c => c.Kegs).ToList();
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
