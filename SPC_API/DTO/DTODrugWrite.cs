using System.ComponentModel.DataAnnotations;

namespace SPC_API.DTO
{
    public class DTODrugWrite
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Type { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
