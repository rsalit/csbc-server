using Microsoft.EntityFrameworkCore;

namespace csbc_server.Data
{
    public class CsbcContext : DbContext
    {
        public CsbcContext(
            DbContextOptions<CsbcContext> options)
            : base(options)
        {
        }

        public DbSet<csbc_server.Models.WebContentType> WebContentType { get; set; }
        public DbSet<csbc_server.Models.WebContent> WebContent { get; set; }

    }
}