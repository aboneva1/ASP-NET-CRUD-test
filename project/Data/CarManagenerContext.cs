using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarManagener.Models;

namespace CarManagener.Data
{
    public class CarManagenerContext : DbContext
    {
        public CarManagenerContext (DbContextOptions<CarManagenerContext> options)
            : base(options)
        {
        }

        public DbSet<CarManagener.Models.Car> Car { get; set; } 

        public DbSet<CarManagener.Models.People>? People { get; set; }

        public DbSet<CarManagener.Models.LipGloss>? LipGloss { get; set; }

    }
}
