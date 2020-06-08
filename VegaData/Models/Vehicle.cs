using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VegaData.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Models Model { get; set; }
        public bool isRegistered { get; set; }
        [Required][StringLength(40)] public string ContactName { get; set; }
        [Required] [StringLength(40)] public string ContactPhone { get; set; }
        [StringLength(40)] public string ContactEmail { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<VehicleFeature> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}
