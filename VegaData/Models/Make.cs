using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VegaData.Models
{
    //[JsonObject(IsReference = true)]
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Models> Models { get; set; }
    }
}
