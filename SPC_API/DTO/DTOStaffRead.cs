using System.ComponentModel.DataAnnotations;

namespace SPC_API.DTO
{
    public class DTOStaffRead
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        
        public String UserName { get; set; }
     
        public string Password { get; set; }
    }
}
