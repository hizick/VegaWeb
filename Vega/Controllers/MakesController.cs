using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var listing = new List<MakeResource>();
            //returns status code with object
            foreach (var make in allMakes)
            {
                var makeResource = new MakeResource();

                makeResource.Id = make.Id;
                makeResource.Name = make.Name;
                makeResource.Models = getModel(make.Models);
                listing.Add(makeResource);
            }

            return Ok(listing);
        }

        public ICollection<ConstantPair> getModel(ICollection<Models> models)
        {
            ICollection<ConstantPair> modelResourceList = new Collection<ConstantPair>();
            foreach (var item in models)
            {
                var modelResource = new ConstantPair();

                modelResource.Id = item.Id;
                modelResource.Name = item.Name;
                modelResourceList.Add(modelResource);
            }
            return modelResourceList;
        }
    }
}
