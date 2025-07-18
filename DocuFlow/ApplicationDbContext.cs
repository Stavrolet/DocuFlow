using DocuFlow.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocuFlow
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<DocumentTemplate>().Ignore(d => d.Content);
            modelBuilder.Entity<DocumentTemplate>().Property(d => d.Title).HasMaxLength(150);

            modelBuilder.Entity<ApplicationUser>().Property(u => u.FirstName).HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.LastName).HasMaxLength(50);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName).HasMaxLength(100);
			modelBuilder.Entity<ApplicationUser>().Property(u => u.Position).HasMaxLength(100);
            modelBuilder.Entity<ApplicationUser>().Property(u => u.Organisation).HasMaxLength(300);
            modelBuilder.Entity<ApplicationUser>().HasKey(u => u.Id);
		}
    }
}
