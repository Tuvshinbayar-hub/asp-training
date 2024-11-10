using DesignAPI_DotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                        
        }

        public DbSet<Design> Designers { get; set; }
        public DbSet<Style> Styles { get; set; }
    }
}
