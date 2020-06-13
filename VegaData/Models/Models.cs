using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace VegaData.Models
{
    //[DataContract(IsReference = true)]
    //[JsonObject(IsReference = true)]
    public class Models
    {
        public int Id { get; set; }
        [Required] [StringLength(49)] public string Name { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
    }
}
