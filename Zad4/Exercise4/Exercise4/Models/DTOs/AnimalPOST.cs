using System.ComponentModel.DataAnnotations;

namespace Exercise4.Models.DTOs
{
    public class AnimalPost
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Category { get; set; } = string.Empty;
        [Required]
        public string Area { get; set; } = string.Empty;
    }
}

