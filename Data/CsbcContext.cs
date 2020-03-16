using Microsoft.EntityFrameworkCore;
using csbc_server.Models;

namespace csbc_server.Data
{
    public class CsbcContext : DbContext
    {
        public CsbcContext()
        {
        }

        public CsbcContext(
            DbContextOptions<CsbcContext> options)
            : base(options)
        {
        }

        public DbSet<csbc_server.Models.WebContentType> WebContentType { get; set; }
        public DbSet<csbc_server.Models.WebContent> WebContent { get; set; }
        public DbSet<csbc_server.Models.Season> Season { get; set; }
        public DbSet<csbc_server.Models.Division> Division { get; set; }

    }
}