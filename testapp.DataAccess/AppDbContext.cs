using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using testapp.Models.DbModels;

namespace testapp.DataAccess
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Answer>Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Disciplines> Disciplines { get; set; }
        public DbSet<Results> Results { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ResultTheme> ResultThemes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}