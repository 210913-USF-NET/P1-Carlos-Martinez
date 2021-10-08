using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    class SCDBContext : DbContext
    {
        public SCDBContext() : base() { }
        public SCDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Weight> Weights { get; set; }

    }
}
