using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using VegaData.Models;

namespace Vega.ViewModel
{
    public class MakeDetailListing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<ModelDetailListing> Models { get; set; }
    }
}
