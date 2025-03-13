using System.ComponentModel.DataAnnotations;

namespace C__Maturita_Practice.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Password { get; set;}
    }
}
