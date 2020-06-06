using System;
using System.Collections.Generic;
using System.Text;
using VegaData.Models;

namespace VegaData.Repositories
{
    public interface IFeatures
    {
        IEnumerable<Feature> GetFeatures();
    }
}
