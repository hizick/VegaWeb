using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VegaData.Models
{
    [Table("VehicleFeatures")]
    public class VehicleFeature
    {
        [JsonIgnore] public int VehicleId { get; set; }
        [JsonIgnore] public int FeatureId { get; set; }
        public Vehicle Vehicle { get; set; }
        public Feature Feature { get; set; }
    }
}
