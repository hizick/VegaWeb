using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VegaData.Models.Context
{
    public class VegaDbContext: DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options){}

        public DbSet <Make> Makes { get; set; }
        public DbSet <Feature> Features { get; set; }
    }
}
