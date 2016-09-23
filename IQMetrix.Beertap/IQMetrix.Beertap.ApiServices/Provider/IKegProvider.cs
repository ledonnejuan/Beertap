using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQMetrix.Beertap.Model;

namespace IQMetrix.Beertap.ApiServices.Provider
{
    public interface IKegProvider
    {
        Keg GetKeg(int id);
        List<Keg> GetKegs();
        Keg GetKegByOfficeId(int officeId, int kegId);
        List<Keg> GetKegByOfficeId(int officeId);
        void UpdateKeg(int officeId, int kegId, int amount);
        void ReplaceKeg(int officeId, int kegId);
    }
}
