using System.ComponentModel.DataAnnotations;

namespace PortfolioMVC.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [StringLength(300)]
        public string? TechStack { get; set; }

        [StringLength(500)]
        public string? GitHubUrl { get; set; }

        [StringLength(500)]
        public string? LiveUrl { get; set; }

        [StringLength(200)]
        public string? ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsFeatured { get; set; } = false;
    }
}
