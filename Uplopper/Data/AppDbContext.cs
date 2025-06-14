using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Uplopper.Models;

namespace Uplopper.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<Photos>Photos {  get; set; }

        public DbSet<Record> Record { get; set; }

    }



    }
