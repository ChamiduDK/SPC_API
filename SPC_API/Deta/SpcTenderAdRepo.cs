using SPC_API.Model;
using System.Collections;
using SPC_API.Data;
using Microsoft.EntityFrameworkCore;

namespace SPC_API.Data
{
    public class SpcTenderAdRepo
    {
        private AppDBContext _dbContext;
        public SpcTenderAdRepo(AppDBContext context)
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
        public bool CreateSpcTenderAd(SpcTenderAd spcTenderAd)
        {
            if (spcTenderAd != null)
            {
                // Automatically generate the Tender_Code
                spcTenderAd.Tender_Code = GenerateTenderCode();

                _dbContext.SpcTenderAds.Add(spcTenderAd);
                return Save();
            }
            else
                return false;
        }
        private string GenerateTenderCode()
        {
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 4); 

            return $"TENDER-{randomPart}"; 
        }

        public bool UpdateSpcTenderAd(SpcTenderAd spcTenderAd)
        {
            if (spcTenderAd != null)
            {
                _dbContext.SpcTenderAds.Update(spcTenderAd);
                return Save();
            }
            else
                return false;
        }
        public bool DeleteSpcTenderAd(SpcTenderAd spcTenderAd)
        {
            if (spcTenderAd != null)
            {
                _dbContext.SpcTenderAds.Remove(spcTenderAd);
                return Save();
            }
            else
                return false;
        }
        public SpcTenderAd GetSpcTenderAdById(int id)
        {
            return _dbContext.SpcTenderAds.FirstOrDefault(t => t.Id == id);
        }
        public IEnumerable<SpcTenderAd> GetSpcTenderAds()
        {
            return _dbContext.SpcTenderAds.ToList();
        }

    }
}
