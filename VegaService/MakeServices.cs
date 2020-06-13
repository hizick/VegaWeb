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

        public Models FindModels(int id)
        {
            return _context.Models.Find(id);
        }

        public Make GetMakeById(int id)
        {
            return _context.Makes.FirstOrDefault(m => m.Id == id);
        }
        
    }
}
