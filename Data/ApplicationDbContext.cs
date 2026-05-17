using Microsoft.EntityFrameworkCore;
using PortfolioMVC.Models;

namespace PortfolioMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Skills
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C#", Category = "Backend", Proficiency = 85 },
                new Skill { Id = 2, Name = "ASP.NET Core MVC", Category = "Backend", Proficiency = 80 },
                new Skill { Id = 3, Name = "MySQL", Category = "Database", Proficiency = 75 },
                new Skill { Id = 4, Name = "HTML & CSS", Category = "Frontend", Proficiency = 90 },
                new Skill { Id = 5, Name = "JavaScript", Category = "Frontend", Proficiency = 78 },
                new Skill { Id = 6, Name = "Entity Framework Core", Category = "Backend", Proficiency = 72 },
                new Skill { Id = 7, Name = "Python", Category = "Backend", Proficiency = 80 },
                new Skill { Id = 8, Name = "Git & GitHub", Category = "Tools", Proficiency = 85 }
            );

            // Seed Projects
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "BeeGuard – Apiculture Management System",
                    Description = "A cross-platform apiculture management system for the Philippine beekeeping sector. Integrates machine learning, GIS mapping, computer vision, and e-commerce. Features AI-based bee species recognition, Pesticide Early Warning System (PEWS), and an e-commerce marketplace with anti-counterfeit QR verification.",
                    TechStack = "Flutter, Python, Firebase, TensorFlow, GIS API",
                    GitHubUrl = "https://github.com/yourusername/beeguard",
                    IsFeatured = true,
                    CreatedAt = new DateTime(2026, 3, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Project
                {
                    Id = 2,
                    Title = "Portfolio MVC Website",
                    Description = "A full-stack personal portfolio website built with ASP.NET Core MVC and MySQL. Features project showcase, skills section, and a working contact form with database persistence.",
                    TechStack = "C#, ASP.NET Core MVC, MySQL, Entity Framework Core, Bootstrap 5",
                    GitHubUrl = "https://github.com/yourusername/portfolio-mvc",
                    IsFeatured = true,
                    CreatedAt = new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Project
                {
                    Id = 3,
                    Title = "NCR Housing Data Analysis",
                    Description = "A data analysis project on 786 NCR housing properties using Python. Performed Pearson/Spearman correlation, quintile segmentation, and created visualizations highlighting Makati real estate trends.",
                    TechStack = "Python, Pandas, Matplotlib, Jupyter Notebook",
                    GitHubUrl = "https://github.com/yourusername/ncr-housing-analysis",
                    IsFeatured = false,
                    CreatedAt = new DateTime(2026, 4, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}
