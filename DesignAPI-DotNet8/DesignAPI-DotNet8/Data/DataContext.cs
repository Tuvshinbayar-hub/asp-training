using DesignAPI_DotNet8.Models;
using DesignAPI_DotNet8.Models.BaseModels;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DesignAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                        
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Design> Designers { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<PantoneColor> PantoneColors { get; set; }
        public DbSet<ColorGroup> ColorGroups { get; set; }

        public DbSet<GobiColor> GobiColors { get; set; }
        public DbSet<ColorShade> ColorShades { get; set; }
        public DbSet<ColorType> ColorTypes { get; set; }
        public DbSet<DandruffClassification> DandruffClassifications { get; set; }
        public DbSet<DyingMethod> DyingMethods { get; set; }
        public DbSet<PaintType> PaintTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region BaseClasses
            // Base Creation configuration
            //modelBuilder.Entity<BaseCreation>(entity =>
            //{
            //    entity.HasOne<User>(e => e.CreatedBy)
            //        .WithOne()
            //        .HasForeignKey("CreatedById")
            //        .OnDelete(DeleteBehavior.SetNull);
            //});

            //// BaseWithModified configuration
            //modelBuilder.Entity<BaseWithModified>(entity =>
            //{
            //    entity.HasOne<User>(e => e.ModifiedBy)
            //        .WithOne()
            //        .HasForeignKey("ModifiedById")
            //        .OnDelete(DeleteBehavior.SetNull);
            //});
            #endregion

            #region Colors
            modelBuilder.Entity<PantoneColor>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired();
                entity.Property(a => a.Code)
                    .IsRequired();
                entity.Property(a => a.RgbHex)
                    .HasMaxLength(7);
            });

            modelBuilder.Entity<ColorType>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<ColorShade>(entity => 
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired();
            });
            #endregion
            
        }
    }
}
