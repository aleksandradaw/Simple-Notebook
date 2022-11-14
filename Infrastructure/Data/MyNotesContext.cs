using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MyNotesContext : DbContext
    {
        public MyNotesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            #region Note
            modelbuilder.Entity<Note>().ToTable("Notes");
            modelbuilder.Entity<Note>().HasKey(x => x.Id);
            modelbuilder.Entity<Note>()
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
            modelbuilder.Entity<Note>()
               .Property(x => x.Content)
               .HasMaxLength(2000);

            #endregion

            #region Category
            modelbuilder.Entity<Category>().ToTable("Categories");
            modelbuilder.Entity<Category>().HasKey(y => y.Id);
            modelbuilder.Entity<Category>()
                .Property(y => y.Name)
                .HasMaxLength(100)
                .IsRequired();
            #endregion

        }
    }
}
