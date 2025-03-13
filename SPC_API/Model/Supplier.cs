using System.ComponentModel.DataAnnotations;

namespace SPC_API.Model
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
