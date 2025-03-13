using System.ComponentModel.DataAnnotations;

namespace SPC_API.DTO
{
    public class DTOOrderWrite 
    {
        public string PharmacyId { get; set; }
        public int DrugId { get; set; }
        public int Quantity { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
