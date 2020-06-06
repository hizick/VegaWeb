using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.ViewModel.Feature;
using VegaData.Models;
using VegaData.Repositories;

namespace Vega.Controllers
{
    public class FeaturesController: Controller
    {
        //private readonly IFeatures 
        public FeaturesController(IFeatures features, IMapper mapper)
        {
            _features = features;
            _mapper = mapper;
        }

        public IFeatures _features { get; }
        public IMapper _mapper { get; }

        [HttpGet("/api/Features")]
        public IActionResult GetFeatures()
        {
            var allFeatures = _features.GetFeatures().ToList();

            var listing = _mapper.Map<List<Feature>, List<FeatureDetailListing>>(allFeatures);
            return Ok(listing);
        }
    }
}
