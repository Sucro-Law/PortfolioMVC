using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Category { get; set; }

        [Range(0, 100)]
        public int Proficiency { get; set; } = 80;
    }
}
