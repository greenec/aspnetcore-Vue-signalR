using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Vue2SpaSignalR.Models
{
    public class Vue2SpaContext : DbContext
    {
        public Vue2SpaContext (DbContextOptions<Vue2SpaContext> options)
            : base(options)
        {
        }

        public DbSet<Vue2SpaSignalR.Models.Employee> Employee { get; set; }
    }
}
