using Microsoft.EntityFrameworkCore;

namespace Vue2SpaSignalR.Models
{
    public class Vue2SpaContext : DbContext
    {
        public Vue2SpaContext(DbContextOptions<Vue2SpaContext> options)
            : base(options)
        {
        }

        public DbSet<Vue2SpaSignalR.Models.Employee> Employee { get; set; }

        public DbSet<Vue2SpaSignalR.Models.WorkItem> WorkItem { get; set; }
    }
}
