using SPC_API.Model;
using System.Collections;
using SPC_API.Data;
using Microsoft.EntityFrameworkCore;

namespace SPC_API.Data
{
    public class StaffRepo
    {
        private AppDBContext _dbContext;
        public StaffRepo(AppDBContext context)
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

        public bool CreateStaff(Staff staff)
        {
            if (staff != null)
            {
                _dbContext.Staffs.Add(staff);
                return Save();
            }
            else
                return false;
        }
        public bool UpdateStaffs(Staff staff)
        {
            if (staff != null)
            {
                _dbContext.Staffs.Update(staff);
                return Save();
            }
            else
                return false;
        }
        public bool DeleteStaff(Staff staff)
        {
            if (staff != null)
            {
                _dbContext.Staffs.Remove(staff);
                return Save();
            }
            else
                return false;
        }
        public Staff GetStaffById(int id)
        {
            return _dbContext.Staffs.FirstOrDefault(s => s.Id == id);
        }
        public IEnumerable<Staff> GetStaffs()
        {
            return _dbContext.Staffs.ToList();
        }
    }
}
