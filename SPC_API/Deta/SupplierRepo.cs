using SPC_API.Model;
using System.Collections;
using SPC_API.Data;
using Microsoft.EntityFrameworkCore;

namespace SPC_API.Data
{
    public class SupplierRepo
    {
        private AppDBContext _dbContext;
        public SupplierRepo(AppDBContext context)
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

        public bool CreateSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                _dbContext.Suppliers.Add(supplier);
                return Save();
            }
            else
                return false;
        }
        public bool UpdateSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                _dbContext.Suppliers.Update(supplier);
                return Save();
            }
            else
                return false;
        }
        public bool DeleteSupplier(Supplier supplier)
        {
            if (supplier != null)
            {
                _dbContext.Suppliers.Remove(supplier);
                return Save();
            }
            else
                return false;
        }
        public Supplier GetSupplierById(int id)
        {
            return _dbContext.Suppliers.FirstOrDefault(t => t.Id == id);
        }
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _dbContext.Suppliers.ToList();
        }
    }
}
