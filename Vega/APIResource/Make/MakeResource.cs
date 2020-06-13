using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VegaData.Models;

namespace Vega.APIResource
{
    public class MakeResource : ConstantPair
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public virtual ICollection<ConstantPair> Models { get; set; }
    }
}
