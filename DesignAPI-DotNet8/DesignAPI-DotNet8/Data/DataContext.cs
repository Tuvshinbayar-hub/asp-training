using DesignAPI_DotNet8.Models;
using DesignAPI_DotNet8.Models.Colors;
using DesignAPI_DotNet8.Models.GobiColor;
using DesignAPI_DotNet8.Models.Users;
using Microsoft.EntityFrameworkCore;
using DesignAPI_DotNet8.Models.GeneralSetup;
using DesignAPI_DotNet8.Models.Sizes;

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

        #region DbSet Colors
        public DbSet<PantoneColor> PantoneColors { get; set; }
        public DbSet<ColorGroup> ColorGroups { get; set; }
        public DbSet<GobiColor> GobiColors { get; set; }
        public DbSet<ColorShade> ColorShades { get; set; }
        public DbSet<ColorType> ColorTypes { get; set; }
        public DbSet<DyingMethod> DyingMethods { get; set; }
        public DbSet<GobiColorRecipeDetail> GobiColorRecipeDetail { get; set; }
        public DbSet<GobiColorRecipeHeader> GobiColorRecipeHeader { get; set; }
        #endregion

        #region DbSet Sizes
        public DbSet<Size> Sizes { get; set; }
        public DbSet<SizeGroup> SizeGroups { get; set; }
        public DbSet<SizeRange> SizeRanges { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<DimensionType> DimensionTypes { get; set; }
        public DbSet<SizeRangeCategory> SizeRangeCategories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TPT Mappings
            modelBuilder.Entity<PantoneColor>().ToTable("PantoneColors");
            modelBuilder.Entity<ColorGroup>().ToTable("ColorGroups");
            modelBuilder.Entity<GobiColor>().ToTable("GobiColors");
            modelBuilder.Entity<ColorShade>().ToTable("ColorShades");
            modelBuilder.Entity<ColorType>().ToTable("ColorTypes");
            modelBuilder.Entity<DyingMethod>().ToTable("DyingMethods");
            modelBuilder.Entity<GobiColorRecipeDetail>().ToTable("GobiColorRecipeDetail");
            modelBuilder.Entity<GobiColorRecipeHeader>().ToTable("GobiColorRecipeHeader");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Image>().ToTable("Image");

            modelBuilder.Entity<Size>().ToTable("Sizes");
            modelBuilder.Entity<SizeGroup>().ToTable("SizeGroups");
            modelBuilder.Entity<SizeRange>().ToTable("SizeRange");
            modelBuilder.Entity<ProductType>().ToTable("ProductTypes");
            modelBuilder.Entity<DimensionType>().ToTable("DimensionTypes");
            modelBuilder.Entity<SizeRangeCategory>().ToTable("SizeRangeCategegories");
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

                // FKs for non PK
                entity.HasOne<PantoneColor>(e => e.PantoneColor)
                    .WithMany()
                    .HasForeignKey(gc => gc.PantoneColorCode)
                    .HasPrincipalKey(pc => pc.PantoneColorCode)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasMany<GobiColorRecipeHeader>(e => e.GobiColorRecipeHeaders)
                    .WithOne()
                    .HasForeignKey(e => e.GobiColorCode)
                    .HasPrincipalKey(e => e.GobiColorCode)
                    .OnDelete(DeleteBehavior.Cascade);
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
                entity.HasMany<GobiColorRecipeDetail>(e => e.GobiColorRecipeDetails)
                    .WithOne()
                    .HasForeignKey(gcrh =>  gcrh.GobiColorCode)
                    .HasPrincipalKey(gcrd => gcrd.GobiColorCode)
                    .OnDelete(DeleteBehavior.Cascade);
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

            #region Sizes
            modelBuilder.Entity<Size>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SkuSizeCode)
                    .IsRequired();
                entity.Property(e => e.SizeName)
                    .IsRequired();
                entity.Property(e => e.SortOrder)
                    .IsRequired();

                // Check if it's working
                entity.HasMany<ProductType>(e => e.ProductTypes)
                    .WithMany();
                entity.HasOne<DimensionType>(e => e.DimensionType)
                    .WithMany()
                    .HasForeignKey(e => e.DimensionTypeId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne<SizeGroup>(e => e.SizeGroup)
                    .WithMany()
                    .HasForeignKey(sg => sg.SizeGroupId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<SizeRange>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.SizeRangeName)
                    .IsRequired();
                entity.Property(e => e.Dimension1TypeId)
                    .IsRequired();
                
                // Check if it's working
                entity.HasMany<ProductType>(e => e.ProductTypes)
                    .WithMany();
                entity.HasOne<SizeRangeCategory>(e => e.SizeRangeCategory)
                    .WithMany()
                    .HasForeignKey(src => src.SizeRangeCategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
                entity.HasOne<DimensionType>(e => e.Dimension1Type)
                    .WithMany()
                    .HasForeignKey(dt => dt.Dimension1TypeId)
                    .OnDelete(DeleteBehavior.Restrict);
                //FKs for non PKs

                entity.HasMany<Size>(e => e.Sizes)
                   .WithMany()
                   .UsingEntity<Dictionary<string, object>>(
                       "SizeRangeSize",
                       j => j
                           .HasOne<Size>()
                           .WithMany()
                           .HasForeignKey("SizeName")
                           .HasPrincipalKey(s => s.SizeName),
                       j => j
                           .HasOne<SizeRange>()
                           .WithMany()
                           .HasForeignKey("SizeRangeId")
                   );
            });

            modelBuilder.Entity<SizeGroup>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired();
            });
            modelBuilder.Entity<DimensionType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired();
            });
            modelBuilder.Entity<SizeRangeCategory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
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
