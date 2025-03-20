using System.ComponentModel.DataAnnotations;

namespace C__Maturita_Practice.Models
{
    public class Note
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Owner {  get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public bool Important { get; set; }


    }
}
