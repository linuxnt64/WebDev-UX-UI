using System.ComponentModel.DataAnnotations;

namespace _01_Forms.Models.Entities

{
    public class ContactFormEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }

    }
}
