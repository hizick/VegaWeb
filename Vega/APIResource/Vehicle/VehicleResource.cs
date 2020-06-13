using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Vega.APIResource.Feature;

namespace Vega.APIResource.Vehicle
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public bool isRegistered { get; set; }
        [Required] public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }
        public DateTime LastUpdated { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}
