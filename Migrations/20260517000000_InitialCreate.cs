using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace PortfolioMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", 1),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "longtext", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", 1),
                    Title = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    TechStack = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    GitHubUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    LiveUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", 1),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Proficiency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "Category", "Proficiency" },
                values: new object[,]
                {
                    { 1, "C#", "Backend", 85 },
                    { 2, "ASP.NET Core MVC", "Backend", 80 },
                    { 3, "MySQL", "Database", 75 },
                    { 4, "HTML & CSS", "Frontend", 90 },
                    { 5, "JavaScript", "Frontend", 78 },
                    { 6, "Entity Framework Core", "Backend", 72 },
                    { 7, "Python", "Backend", 80 },
                    { 8, "Git & GitHub", "Tools", 85 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Title", "Description", "TechStack", "GitHubUrl", "LiveUrl", "ImageUrl", "CreatedAt", "IsFeatured" },
                values: new object[,]
                {
                    {
                        1,
                        "BeeGuard - Apiculture Management System",
                        "A cross-platform apiculture management system for the Philippine beekeeping sector. Integrates machine learning, GIS mapping, computer vision, and e-commerce. Features AI-based bee species recognition, Pesticide Early Warning System (PEWS), and an e-commerce marketplace with anti-counterfeit QR verification.",
                        "Flutter, Python, Firebase, TensorFlow, GIS API",
                        "https://github.com/yourusername/beeguard",
                        null,
                        null,
                        new DateTime(2026, 3, 1, 0, 0, 0, DateTimeKind.Utc),
                        true
                    },
                    {
                        2,
                        "Portfolio MVC Website",
                        "A full-stack personal portfolio website built with ASP.NET Core MVC and MySQL. Features project showcase, skills section, and a working contact form with database persistence.",
                        "C#, ASP.NET Core MVC, MySQL, Entity Framework Core, Bootstrap 5",
                        "https://github.com/yourusername/portfolio-mvc",
                        null,
                        null,
                        new DateTime(2026, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                        true
                    },
                    {
                        3,
                        "NCR Housing Data Analysis",
                        "A data analysis project on 786 NCR housing properties using Python. Performed Pearson/Spearman correlation, quintile segmentation, and created visualizations highlighting Makati real estate trends.",
                        "Python, Pandas, Matplotlib, Jupyter Notebook",
                        "https://github.com/yourusername/ncr-housing-analysis",
                        null,
                        null,
                        new DateTime(2026, 4, 1, 0, 0, 0, DateTimeKind.Utc),
                        false
                    }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ContactMessages");
            migrationBuilder.DropTable(name: "Projects");
            migrationBuilder.DropTable(name: "Skills");
        }
    }
}
