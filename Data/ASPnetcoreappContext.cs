using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPnetcoreapp.Models;

namespace ASPnetcoreapp.Data
{
    public class ASPnetcoreappContext : DbContext
    {
        public ASPnetcoreappContext (DbContextOptions<ASPnetcoreappContext> options)
            : base(options)
        {
        }

        public DbSet<ASPnetcoreapp.Models.Movie> Movie { get; set; } = default!;
    }
}
