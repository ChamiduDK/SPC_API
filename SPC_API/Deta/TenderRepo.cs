using SPC_API.Model;
using System.Collections;
using SPC_API.Data;
using Microsoft.EntityFrameworkCore;

namespace SPC_API.Data
{
    public class TenderRepo
    {
        private readonly AppDBContext _dbContext;

        public TenderRepo(AppDBContext context)
        {
            _dbContext = context;
        }

        public bool Save()
        {
            int count = _dbContext.SaveChanges();
            return count > 0;
        }

        public bool CreateTender(Tender tender)
        {
            try
            {
                _dbContext.Tenders.Add(tender);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateTender(Tender tender)
        {
            if (tender != null)
            {
                _dbContext.Tenders.Update(tender);
                return Save();
            }
            return false;
        }

        public bool DeleteTender(Tender tender)
        {
            if (tender != null)
            {
                _dbContext.Tenders.Remove(tender);
                return Save();
            }
            return false;
        }

        public Tender GetTenderById(int id)
        {
            return _dbContext.Tenders.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Tender> GetTenders()
        {
            return _dbContext.Tenders.ToList();
        }

        // New method to get tenders by SupplierId
        public IEnumerable<Tender> GetTendersBySupplier(string supplierId)
        {
            return _dbContext.Tenders.Where(t => t.SupplierId == supplierId).ToList();
        }
    }
}

