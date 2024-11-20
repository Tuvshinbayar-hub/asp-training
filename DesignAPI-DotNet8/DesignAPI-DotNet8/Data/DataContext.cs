using DesignAPI_DotNet8.Models;
using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.Colors;
using DesignAPI_DotNet8.Models.GobiColor;
using DesignAPI_DotNet8.Models.Users;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<DyingMethod> DyingMethods { get; set; }
        public DbSet<PaintType> PaintTypes { get; set; }
        public DbSet<ColorRecipe> ColorRecipes { get; set; }

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
            //modelBuilder.Entity<Base>().ToTable("Base");
            //modelBuilder.Entity<BaseCreation>().ToTable("BaseCreation");
            //modelBuilder.Entity<BaseWithModified>().ToTable("BaseWithModified");

            #endregion

            #region TPT Mappings
            modelBuilder.Entity<PantoneColor>().ToTable("PantoneColors");
            modelBuilder.Entity<ColorGroup>().ToTable("ColorGroups");
            modelBuilder.Entity<GobiColor>().ToTable("GobiColors");
            modelBuilder.Entity<ColorShade>().ToTable("ColorShades");
            modelBuilder.Entity<ColorType>().ToTable("ColorTypes");
            modelBuilder.Entity<DyingMethod>().ToTable("DyingMethods");
            modelBuilder.Entity<PaintType>().ToTable("PaintTypes");
            modelBuilder.Entity<ColorRecipe>().ToTable("ColorRecipe");
            modelBuilder.Entity<User>().ToTable("Users");
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
                entity.HasOne<ColorGroup>(e => e.ColorGroup)
                    .WithMany()
                    .HasForeignKey("ColorGroupId")
                    .OnDelete(DeleteBehavior.SetNull);
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

            modelBuilder.Entity<GobiColor>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.GobiColorCode)
                    .IsRequired();
                entity.Property(a => a.FourDigitColorCode)
                    .IsRequired()
                    .HasMaxLength(4);
                entity.HasOne<ColorType>(e => e.ColorType)
                    .WithMany()
                    .HasForeignKey("ColorTypeId")
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne<ColorShade>(e => e.ColorShade)
                    .WithMany()
                    .HasForeignKey("ColorShadeId")
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne<PantoneColor>(e => e.PantoneColor)
                    .WithMany()
                    .HasForeignKey("PantoneColorId")
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne<ColorRecipe>(e => e.ColorRecipe)
                    .WithMany()
                    .HasForeignKey("ColorRecipeId")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ColorRecipe>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.ColorComposition)
                    .IsRequired();
                entity.HasMany<PaintType>(e => e.PaintTypes)
                    .WithMany();
            });

            modelBuilder.Entity<ColorGroup>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<DyingMethod>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<PaintType>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired();
            });
            #endregion            
        }
    }
}
