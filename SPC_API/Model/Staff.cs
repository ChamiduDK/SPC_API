using System.ComponentModel.DataAnnotations;

namespace SPC_API.Model
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
