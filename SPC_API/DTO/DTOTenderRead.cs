using System.ComponentModel.DataAnnotations;

namespace SPC_API.DTO
{
    public class DTOTenderRead
    {
        public int Id { get; set; }
        public string SupplierId { get; set; }

        public string Tender_Code { get; set; }
        public string Drug { get; set; }
        public string Description { get; set; }
   
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public bool Status { get; set; }
    }
}
