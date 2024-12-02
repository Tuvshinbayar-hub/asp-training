using DesignAPI_DotNet8.Models;
using DesignAPI_DotNet8.Models.Colors;
using DesignAPI_DotNet8.Models.GobiColor;
using DesignAPI_DotNet8.Models.Users;
using Microsoft.EntityFrameworkCore;
using DesignAPI_DotNet8.Models.GeneralSetup;

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
        public DbSet<GobiColorRecipeDetail> PaintTypes { get; set; }
        public DbSet<GobiColorRecipeHeader> ColorRecipes { get; set; }

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
            modelBuilder.Entity<GobiColorRecipeDetail>().ToTable("PaintTypes");
            modelBuilder.Entity<GobiColorRecipeHeader>().ToTable("ColorRecipe");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Image>().ToTable("Image");
            #endregion

            #region Colors
            modelBuilder.Entity<PantoneColor>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasIndex(a => a.GobiColorCode)
                    .IsUnique();
                entity.Property(a => a.GobiColorCode)
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
                entity.HasIndex(a => a.GobiColorCode)
                    .IsUnique();
                entity.Property(a => a.GobiColorCode)
                    .IsRequired();
                entity.Property(a => a.FourDigitColorCode)
                    .IsRequired()
                    .HasMaxLength(4);
                entity.HasOne<ColorType>(e => e.ColorType)
                    .WithMany()
                    .HasForeignKey(ct => ct.ColorTypeId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne<ColorShade>(e => e.ColorShade)
                    .WithMany()
                    .HasForeignKey(cs => cs.ColorShadeId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne<PantoneColor>(e => e.PantoneColor)
                    .WithMany()
                    .HasForeignKey(e => e.GobiColorCode)
                    .HasPrincipalKey(e => e.GobiColorCode)
                    .OnDelete(DeleteBehavior.SetNull);

                // FKs
                entity.HasMany<GobiColorRecipeHeader>(e => e.GobiColorRecipeHeaders)
                    .WithOne()
                    .HasForeignKey(e => e.GobiColorCode)
                    .HasPrincipalKey(e => e.GobiColorCode)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasMany<GobiColorRecipeDetail>(e => e.GobiColorRecipeDetails)
                    .WithOne()
                    .HasForeignKey(e => e.GobiColorCode)
                    .HasPrincipalKey(e => e.GobiColorCode)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<GobiColorRecipeHeader>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasIndex(a => a.GobiColorCode)
                    .IsUnique();
                entity.Property(a => a.GobiColorCode)
                    .IsRequired();
                entity.Property(a => a.ColorComposition)
                    .IsRequired();
            });

            modelBuilder.Entity<GobiColorRecipeDetail>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasIndex(a => a.GobiColorCode)
                    .IsUnique();    
                entity.Property(a => a.GobiColorCode)
                    .IsRequired();
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

            #endregion

            #region Supplier
            //modelBuilder.Entity<Supplier>(entity =>
            //{
            //    entity.HasMany(s => s.Agents)
            //        .WithMany()
            //        .HasQuery
            //});
            #endregion
        }
    }
}
