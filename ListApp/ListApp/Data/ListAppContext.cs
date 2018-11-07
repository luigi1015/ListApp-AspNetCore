using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ListApp.Models;

namespace ListApp.Models
{
    public class ListAppContext : DbContext
    {
        public ListAppContext (DbContextOptions<ListAppContext> options)
            : base(options)
        {
        }

        public DbSet<ListApp.Models.List> List { get; set; }

        public DbSet<ListApp.Models.ListItem> ListItem { get; set; }
    }
}
