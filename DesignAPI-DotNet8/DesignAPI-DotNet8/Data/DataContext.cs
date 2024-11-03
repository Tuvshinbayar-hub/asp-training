using DesignAPI_DotNet8.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Design> Designers { get; set; }
    }
}
