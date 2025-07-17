using DocuFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace DocuFlow
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<DocumentTemplate> DocumentTemplates { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentTemplate>().Ignore(d => d.Content);
            modelBuilder.Entity<DocumentTemplate>().Property(d => d.Title).HasMaxLength(150);
		}
    }
}
