using Domain.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Publication> Publications { get; set; } = default!;
        public DbSet<PublicationAuthor> PublicationAuthors { get; set; } = default!;
        public DbSet<PublicationLanguage> PublicationLanguages { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Item> Items { get; set; } = default!;
        public DbSet<Library> Libraries { get; set; } = default!;
        public DbSet<LibraryOpenTime> LibraryOpenTimes { get; set; } = default!;
        public DbSet<Work> Works { get; set; } = default!;
        public DbSet<WorkAuthor> WorkAuthors { get; set; } = default!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Library>()
                .Property(l => l.LibraryStatus)
                .HasDefaultValue(LibraryStatus.Status2);
        }
    }
}