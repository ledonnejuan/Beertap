using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.ApiServices.Provider
{
    public class KegProvider : IKegProvider
    {
        private static List<Keg> _kegs;
        private static List<Keg> _officeKegs;

        private readonly IOfficeProvider _officeProvider;
        public KegProvider(IOfficeProvider officeProvider)
        {
            _officeProvider = officeProvider;
            if (_kegs == null)
            {
                //initialize data
                _kegs = new List<Keg>();
                _kegs.Add(new Keg() { Id = 1, Capacity = 10000, Remaining = 10000, Content = "Beer", OfficeId = 0, KegState = KegState.New });
                _kegs.Add(new Keg() { Id = 2, Capacity = 10000, Remaining = 10000, Content = "Draft Beer", OfficeId = 0, KegState = KegState.New });
            }
            if (_officeKegs == null)
            {
                //init office's keg
                _officeKegs = new List<Keg>();
                var tmpKeg = _kegs.First();
                foreach (var office in _officeProvider.GetOffices())
                {
                    var keg = new Keg()
                    {
                        Id = tmpKeg.Id,
                        Capacity = tmpKeg.Capacity,
                        Remaining = tmpKeg.Remaining,
                        Content = tmpKeg.Content,
                        OfficeId = office.Id,
                        KegState = tmpKeg.KegState
                    };
                    _officeKegs.Add(keg);
                }
            }
        }
        
        public Keg GetKeg(int id)
        {
            return _kegs.Find(c => c.Id == id);
        }

        public List<Keg> GetKegs()
        {
            return _kegs;
        }

        public Keg GetKegByOfficeId(int officeId, int kegId)
        {
            return _officeKegs.Find(c => c.OfficeId == officeId && c.Id == kegId);
        }

        public List<Keg> GetKegByOfficeId(int officeId)
        {
            return _officeKegs.Where(c => c.OfficeId == officeId).ToList();
        }

        public void UpdateKeg(int officeId, int kegId, int amount)
        {
            var keg = _officeKegs.Find(c => c.OfficeId == officeId && c.Id == kegId);
            keg.Remaining = keg.Remaining - amount;

            var pc = ((double)keg.Remaining / (double)keg.Capacity) * 100;

            if(pc == 100)
                keg.KegState = KegState.New;
            else if (pc < 100 && pc >= 15)
                keg.KegState = KegState.GoinDown;
            else if (pc < 15 && pc > 0)
                keg.KegState = KegState.AlmostEmpty;
            else
                keg.KegState = KegState.SheIsDryMate;

            _officeKegs.Find(c => c.OfficeId == officeId && c.Id == kegId).Remaining = keg.Remaining < 0 ? 0 : keg.Remaining;
            _officeKegs.Find(c => c.OfficeId == officeId && c.Id == kegId).KegState = keg.KegState;
        }

        public void ReplaceKeg(int officeId, int kegId)
        {
            var keg = _officeKegs.Find(c => c.OfficeId == officeId && c.Id == kegId);
            _officeKegs.Find(c => c.OfficeId == officeId && c.Id == kegId).Remaining = keg.Capacity;
            _officeKegs.Find(c => c.OfficeId == officeId && c.Id == kegId).KegState = KegState.New;
        }
    }
}
