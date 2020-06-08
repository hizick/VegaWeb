using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.APIResource;
using VegaData.Models;
using VegaData.Repositories;

namespace Vega.Controllers
{
    public class MakesController: Controller
    {
        private IMakes makes;
        private readonly IMapper mapper;

        public MakesController(IMakes makes, IMapper mapper)
        {
            this.makes = makes;
            this.mapper = mapper;
        }
        
        [HttpGet("/api/Makes")]
        public IActionResult GetAllMakes()
        {
            var allMakes = makes.GetAllMakes();
            var listing = mapper.Map<IEnumerable<Make>, IEnumerable<MakeResource>>(allMakes);
            //returns status code with object
            return Ok(listing);
        }
    }
}
