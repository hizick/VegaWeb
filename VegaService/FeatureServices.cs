using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VegaData.Models;
using VegaData.Models.Context;
using VegaData.Repositories;

namespace VegaService
{
    public class FeatureServices : IFeatures
    {
        private readonly VegaDbContext _context;
        public FeatureServices(VegaDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Feature> GetFeatures()
        {
            return _context.Features;
        }
    }
}
