using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookShop.Models
{
    public partial class BooksDBContext : DbContext
    {
        public BooksDBContext()
        {
        }

        public BooksDBContext(DbContextOptions<BooksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
       
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersBooks> UsersBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=BooksDB; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FullName).HasMaxLength(100);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Books__AuthorId__4D94879B");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Books__GenreId__4E88ABD4");
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);
            });

          

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            modelBuilder.Entity<UsersBooks>(entity =>
            {
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.UsersBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__UsersBook__BookI__3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersBooks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsersBook__UserI__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
