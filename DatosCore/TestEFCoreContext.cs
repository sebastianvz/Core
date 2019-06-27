using System;
using DatosCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DatosCore
{
    public partial class TestEFCoreContext : DbContext
    {
        public TestEFCoreContext()
        {
        }

        public TestEFCoreContext(DbContextOptions<TestEFCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESARROLLO2-PC\\MSSQL;Database=TestEFCore;Trusted_Connection=True;User Id=sebas; Password=sebas;");
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
