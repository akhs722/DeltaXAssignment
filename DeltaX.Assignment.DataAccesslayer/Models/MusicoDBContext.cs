using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DeltaX.Assignment.DataAccesslayer.Models
{
    public partial class MusicoDBContext : DbContext
    {
        public MusicoDBContext()
        {
        }

        public MusicoDBContext(DbContextOptions<MusicoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artists> Artists { get; set; }
        public virtual DbSet<SongArtistRelation> SongArtistRelation { get; set; }
        public virtual DbSet<Songs> Songs { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserRating> UserRating { get; set; }
        public virtual DbSet<TopTenArtists> TopTenArtists { get; set; }
        public virtual DbSet<ArtistsName> ArtistsName { get; set; }
        public virtual DbSet<TopTenSongs> TopTenSongs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source =localhost\\SQLEXPRESS;Initial Catalog=MusicoDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artists>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.Property(e => e.ArtistId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ArtistName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Bio)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");
            });

            modelBuilder.Entity<SongArtistRelation>(entity =>
            {
                entity.HasKey(e => new { e.SongId, e.ArtistId });

                entity.Property(e => e.SongId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ArtistId).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.SongArtistRelation)
                    .HasForeignKey(d => d.ArtistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SongArtis__Artis__3F115E1A");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.SongArtistRelation)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SongArtis__SongI__3E1D39E1");
            });

            modelBuilder.Entity<Songs>(entity =>
            {
                entity.HasKey(e => e.SongId);

                entity.Property(e => e.SongId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateOfRelease).HasColumnType("date");

                entity.Property(e => e.ImageCoverLocation)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.SongName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => e.Userid);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__UserDeta__AB6E61643E608306")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRating>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SongId).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.UserRating)
                    .HasForeignKey(d => d.SongId)
                    .HasConstraintName("FK__UserRatin__SongI__42E1EEFE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRating)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__UserRatin__useri__41EDCAC5");
            });
        }
    }
}
