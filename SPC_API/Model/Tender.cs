using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPC_API.Model
{
    public class Tender
    {
        [Key]
        public int Id { get; set; }
        public string SupplierId { get; set; }
        [Required]
        public string Tender_Code { get; set; }
        [Required]
        public string Drug { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
    }
}
