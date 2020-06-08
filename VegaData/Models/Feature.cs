using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VegaData.Models
{
    public class Feature
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<VehicleFeature> Vehicles { get; set; }
        public Feature()
        {
            Vehicles = new Collection<VehicleFeature>();
        }
    }
}
