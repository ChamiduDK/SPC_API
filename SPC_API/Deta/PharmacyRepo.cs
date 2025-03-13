using SPC_API.Model;
using System.Collections;
using SPC_API.Data;
using Microsoft.EntityFrameworkCore;


namespace SPC_API.Data
{
    public class PharmacyRepo
    {
        private AppDBContext _dbContext;
        public PharmacyRepo(AppDBContext context)
        {
            _dbContext = context;
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            if (count > 0)
                return true;
            else
                return false;
        }

        public bool CreatePharmacy(Pharmacy pharmacy)
        {
            if (pharmacy != null)
            {
                _dbContext.Pharmacies.Add(pharmacy);
                return Save();
            }
            else
                return false;
        }
        public bool UpdatePharmacy(Pharmacy pharmacy)
        {
            if (pharmacy != null)
            {
                _dbContext.Pharmacies.Update(pharmacy);
                return Save();
            }
            else
                return false;
        }
        public bool DeletePharmacy(Pharmacy pharmacy)
        {
            if (pharmacy != null)
            {
                _dbContext.Pharmacies.Remove(pharmacy);
                return Save();
            }
            else
                return false;
        }
        public Pharmacy GetPharmacyById(int id)
        {
            return _dbContext.Pharmacies.FirstOrDefault(t => t.Id == id);
        }
        public IEnumerable<Pharmacy> GetPharmacies()
        {
            return _dbContext.Pharmacies.ToList();
        }
    }
}
