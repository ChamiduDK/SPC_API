using System.ComponentModel.DataAnnotations;

namespace SPC_API.Model
{
    public class SpcTenderAd
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Tender_Code { get; set; }
        [Required]
        public string Drug_Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public DateTime Due_Date  { get; set; }
        public bool Status { get; set; }
    }
}
