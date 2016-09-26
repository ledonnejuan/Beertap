using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.Data.Providers
{
    public class KegProvider : IKegProvider
    {
        private readonly IBeertapRepository<Keg> _kegRepository;

        public KegProvider(IBeertapRepository<Keg> kegRepository)
        {
            _kegRepository = kegRepository;
        }
        public Keg GetKeg(int id)
        {
            return _kegRepository.FindBy(c => c.Id.Equals(id)).Include(c => c.Office).FirstOrDefault();
        }

        public List<Keg> GetKegs()
        {
            return _kegRepository.GetAll().ToList();
        }

        public List<Keg> GetKegByOfficeId(int officeId)
        {
            return _kegRepository.FindBy(c => c.OfficeId.Equals(officeId)).Include(k => k.Office).ToList();
        }

        public void UpdateKeg(int officeId, int kegId, int amount)
        {
            var keg = _kegRepository.FindBy(c => c.Id == kegId).Include(c => c.Office).FirstOrDefault();
            
            keg.Remaining = (keg.Remaining - amount) < 0 ? 0 : (keg.Remaining - amount);

            var pc = ((double)keg.Remaining / (double)keg.Capacity) * 100;

            if (pc == 100)
                keg.KegState = KegState.New;
            else if (pc < 100 && pc >= 15)
                keg.KegState = KegState.GoinDown;
            else if (pc < 15 && pc > 0)
                keg.KegState = KegState.AlmostEmpty;
            else
                keg.KegState = KegState.SheIsDryMate;
            keg.Office.ObjectState = ObjectState.Unchanged;
            _kegRepository.Update(keg);
        }

        public void ReplaceKeg(int officeId, int kegId)
        {
            var keg = _kegRepository.FindBy(c => c.Id == kegId).FirstOrDefault();
            keg.Remaining = keg.Capacity;
            keg.KegState = KegState.New;

            _kegRepository.Update(keg);
        }
    }
}
