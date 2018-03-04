using Microsoft.EntityFrameworkCore;

namespace Vue2SpaSignalR.Models
{
    public class Vue2SpaContext : DbContext
    {
        public Vue2SpaContext(DbContextOptions<Vue2SpaContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<WorkItem> WorkItem { get; set; }

        [DbFunction("SOUNDEX")]
        public static string Soundex(string s) => throw new System.NotSupportedException();
    }
}
