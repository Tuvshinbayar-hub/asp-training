using DesignAPI_DotNet8.Models;
using DesignAPI_DotNet8.Models.Colors;
using DesignAPI_DotNet8.Models.GobiColor;
using DesignAPI_DotNet8.Models.Users;
using Microsoft.EntityFrameworkCore;
using DesignAPI_DotNet8.Models.GeneralSetup;
using DesignAPI_DotNet8.Models.Sizes;
using DesignAPI_DotNet8.Models.Grading;

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

        #region DbSet Grading
        public DbSet<GradingHeader> GradingHeaders { get; set; }
        public DbSet<GradingPitch> GradingPitches { get; set; }
        public DbSet<Dimension> Dimensions { get; set; }
        public DbSet<ToleranceHeader> ToleranceHeaders { get; set; }
        public DbSet<ToleranceDetail> ToleranceDetails { get; set; }
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

            modelBuilder.Entity<GradingHeader>().ToTable("GradingHeaders");
            modelBuilder.Entity<GradingPitch>().ToTable("GradingPitches");
            modelBuilder.Entity<Dimension>().ToTable("Dimensions");
            modelBuilder.Entity<ToleranceHeader>().ToTable("ToleranceHeaders");
            modelBuilder.Entity<ToleranceDetail>().ToTable("ToleranceDetails");
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
                    .HasForeignKey(e => e.DimensionTypeId);
                entity.HasOne<SizeGroup>(e => e.SizeGroup)
                    .WithMany()
                    .HasForeignKey(sg => sg.SizeGroupId);
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

            #region Grading
            modelBuilder.Entity<GradingHeader>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.HasIndex(a => a.Increment)
                    .IsUnique();
                entity.Property(a => a.Increment)
                    .IsRequired();
                entity.HasMany<GradingPitch>(e => e.GradingPitches)
                    .WithOne()
                    .HasForeignKey(gh => gh.Increment)
                    .HasPrincipalKey(gp => gp.Increment);

                entity.HasOne<SizeRange>(e => e.SizeRange)
                    .WithMany()
                    .HasForeignKey(gh => gh.SizeRangeName)
                    .HasPrincipalKey(sr => sr.SizeRangeName);

                entity.HasMany<Size>(e => e.Sizes)
                    .WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "GradingHeaderSize",
                        j => j
                            .HasOne<Size>()
                            .WithMany()
                            .HasForeignKey("SizeName")
                            .HasPrincipalKey(s => s.SizeName),
                        j => j
                            .HasOne<GradingHeader>()
                            .WithMany()
                            .HasForeignKey("GradingHeaderId")
                        );

                entity.HasOne<Size>(e => e.BaseSize)
                    .WithMany()
                    .HasForeignKey(gh => gh.BaseSizeName)
                    .HasPrincipalKey(s => s.SizeName);
            });

            modelBuilder.Entity<GradingPitch>(entity => 
            { 
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Increment)
                    .IsRequired();
                entity.HasIndex(e => e.Increment)
                    .IsUnique();
                entity.Property(e => e.DimensionName)
                    .IsRequired();

                entity.HasOne<Dimension>(e => e.Dimension)
                    .WithMany()
                    .HasForeignKey(gp => gp.DimensionName)
                    .HasPrincipalKey(d => d.DimensionName)
                    .IsRequired();

                entity.HasOne<ProductType>(e => e.ProductType)
                    .WithMany()
                    .HasForeignKey(pt => pt.ProductTypeId);
            });

            modelBuilder.Entity<Dimension>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DimensionName)
                    .IsRequired();
                entity.HasIndex(e => e.DimensionName)
                    .IsUnique();
            });

            modelBuilder.Entity<ToleranceHeader>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(e => e.Tolerance)
                    .IsRequired();
                entity.HasOne<ToleranceDetail>(e => e.ToleranceDetail)
                    .WithOne()
                    .HasForeignKey<ToleranceHeader>(th => th.Tolerance)
                    .HasPrincipalKey<ToleranceDetail>(td => td.DimensionName);

                entity.HasMany<GradingHeader>(e => e.GradingHeaders)
                    .WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                            "ToleranceHeaderGradingHeader",
                            j => j
                                .HasOne<GradingHeader>()
                                .WithMany()
                                .HasForeignKey("Increment")
                                .HasPrincipalKey(s => s.Increment),
                            j => j
                                .HasOne<ToleranceHeader>()
                                .WithMany()
                                .HasForeignKey("ToleranceHeaderId")
                        );

                entity.HasMany<Dimension>(e => e.Dimensions)
                    .WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                            "ToleranceHeaderDimension",
                            j => j
                            .HasOne<Dimension>()
                            .WithMany()
                            .HasForeignKey("DimensionName")
                            .HasPrincipalKey(d => d.DimensionName),
                            j => j
                            .HasOne<ToleranceHeader>()
                            .WithMany()
                            .HasForeignKey("ToleranceHeaderId")
                        );
            });

            modelBuilder.Entity<ToleranceDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.DimensionName);
                entity.HasIndex(e => e.Tolerance);

                entity.HasOne<Dimension>(e => e.Dimension)
                    .WithMany()
                    .HasForeignKey(td => td.DimensionName)
                    .HasPrincipalKey(d => d.DimensionName)
                    .OnDelete(DeleteBehavior.Restrict);
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
