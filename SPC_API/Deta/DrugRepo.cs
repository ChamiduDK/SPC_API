using SPC_API.Model;
using System.Collections;
using SPC_API.Data;
using Microsoft.EntityFrameworkCore;

namespace SPC_API.Data
{
    public class DrugRepo
    {
        private AppDBContext _dbContext;
        public DrugRepo(AppDBContext context)
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

        public bool CreateDrug(Drug drug)
        {
            if (drug != null) 
             {
               _dbContext.Drugs.Add(drug);
                return Save();
             }else
                return false;
        }
        public bool UpdateDrug(Drug drug)
        {
            if (drug != null)
            {
                _dbContext.Drugs.Update(drug);
                return Save();
            }
            else
                return false;
        }
        public bool DeleteDrug(Drug drug) {
            if (drug != null)
            {
                _dbContext.Drugs.Remove(drug);
                return Save();
            }
            else
                return false;
        }
        public Drug GetDrugById(int id) 
        {
            return _dbContext.Drugs.FirstOrDefault(d => d.Id == id);
        }
        public IEnumerable<Drug> GetDrugs()
        {
            return _dbContext.Drugs.ToList();
        }
    }

}
