using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaData.Models;
using VegaData.Models.Context;
using VegaData.Repositories;

namespace VegaService
{
    public class MakeServices : IMakes
    {
        private readonly VegaDbContext _context;
        public MakeServices(VegaDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Make> GetAllMakes()
        {
            return _context.Makes.Include(m => m.Models);
        }
    }
}
