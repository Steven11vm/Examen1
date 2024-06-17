using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Peaje.Models;

namespace Peaje.Data
{
    


        public partial class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }
    
            public DbSet<Peaje.Models.PeajesM> PeajeM { get; set; }


        }
    
}
