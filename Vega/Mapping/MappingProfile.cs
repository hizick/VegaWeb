using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.APIResource;
using Vega.APIResource.Feature;
using Vega.APIResource.Vehicle;
using VegaData.Models;

namespace Vega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API
            CreateMap<Make, MakeResource>();
            CreateMap<Models, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vd => vd.Contact, opt => opt.MapFrom(v => new ContactResource { ContactName = v.ContactName, ContactEmail = v.ContactEmail, ContactPhone = v.ContactPhone }))
                .ForMember(vd => vd.Features, opt => opt.MapFrom(v => v.Features.Select(f => f.FeatureId)));
            //API to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vd => vd.Contact.ContactName))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vd => vd.Contact.ContactEmail))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vd => vd.Contact.ContactPhone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                  // Remove unselected features
                  var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                  foreach (var f in removedFeatures)
                      v.Features.Remove(f);

                  // Add new features
                  var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id });
                  foreach (var f in addedFeatures)
                      v.Features.Add(f);
                });


        }

    }
}
