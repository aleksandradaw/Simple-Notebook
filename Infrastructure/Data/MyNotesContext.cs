using System.Runtime.CompilerServices;

namespace Infrastructure.Data
{
    public class MyNotesContext : DbContext
    {
        public MyNotesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NoteDetails> NotesDetails { get; set; }    

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
            modelbuilder.Entity<Note>()
                .HasOne(x => x.Details)
                .WithOne(y => y.Note)
                .HasForeignKey<NoteDetails>(NoteDetails => NoteDetails.NoteId);
            modelbuilder.Entity<Note>()
                .HasOne(x => x.Category)
                .WithMany(y => y.Notes)
                .HasForeignKey(c => c.CategoryId);

            #endregion

            #region Category
            modelbuilder.Entity<Category>().ToTable("Categories");
            modelbuilder.Entity<Category>().HasKey(y => y.Id);
            modelbuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            modelbuilder.Entity<Category>()
                .Property(y => y.Name)
                .HasMaxLength(100)
                .IsRequired();
              
            #endregion

            #region NoteDetails
            modelbuilder.Entity<NoteDetails>().ToTable("NoteDetails");
            modelbuilder.Entity<NoteDetails>().HasKey(y => y.Id);
            modelbuilder.Entity<NoteDetails>()
                .Property(y => y.Created)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();
            modelbuilder.Entity<NoteDetails>()
                .Property(y => y.Updated)
                .HasColumnType("datetime2").HasPrecision(0)
                .IsRequired();
            #endregion
        }
    }
}
