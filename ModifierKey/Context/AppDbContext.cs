using Microsoft.EntityFrameworkCore;
using ModifierKey.Models;

namespace ModifierKey.Context
{
    #region DbContext
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<ModifierKeyword> ModifierKeywords { get; set; }
    }

    #endregion
}
