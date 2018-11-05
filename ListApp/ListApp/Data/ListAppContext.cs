using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ListApp.Models
{
    public class ListAppContext : DbContext
    {
        public ListAppContext (DbContextOptions<ListAppContext> options)
            : base(options)
        {
        }

        public DbSet<ListApp.Models.List> List { get; set; }
    }
}
