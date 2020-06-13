using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.APIResource.Feature;

namespace Vega.APIResource.Vehicle
{
    public class VehicleData
    {
        public int Id { get; set; }
        public ConstantPair Make { get; set; }
        public ConstantPair Model { get; set; }
        public bool isRegistered { get; set; }
        public ContactResource Contact { get; set; }
        public ICollection<ConstantPair> Features { get; set; }
        public DateTime LastUpdated { get; set; }

        public VehicleData()
        {
            Features = new Collection<ConstantPair>();
        }
    }
}
