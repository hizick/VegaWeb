using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.ViewModel;
using Vega.ViewModel.Feature;
using VegaData.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeDetailListing>();
            CreateMap<Models, ModelDetailListing>();
            CreateMap<Feature, FeatureDetailListing>();
        }

    }
}
