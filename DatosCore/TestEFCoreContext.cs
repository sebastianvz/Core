using System;
using DatosCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DatosCore
{
    public partial class TestEFCoreContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public TestEFCoreContext()
        {
        }

        public TestEFCoreContext(DbContextOptions<TestEFCoreContext> options, IConfiguration _configuration)
            : base(options)
        {
            this._configuration = _configuration;
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["db"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ditalfinger)
                    .HasColumnName("ditalfinger")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPeson).HasColumnName("idPeson");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.person)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdPeson)
                    .HasConstraintName("FK_user_person");
            });
        }
    }
}
