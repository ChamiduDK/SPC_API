using System.ComponentModel.DataAnnotations;

namespace SPC_API.DTO
{
    public class DTOSpcTenderAdRead
    {
        public int Id { get; set; }
        public string Tender_Code { get; set; }
        public string Drug_Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public DateTime Due_Date { get; set; }
        public bool Status { get; set; }

    }
}
