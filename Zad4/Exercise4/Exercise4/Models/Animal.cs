using System.ComponentModel.DataAnnotations;

namespace Exercise4.Models
{
    public class Animal
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Area { get; set; }
    }
}
