using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VegaData.Models
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Models> Models { get; set; }
    }
}
