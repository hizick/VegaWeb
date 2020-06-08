using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VegaData.Models;

namespace VegaData.Repositories
{
    public interface IMakes
    {
        IEnumerable<Make> GetAllMakes();
        Models.Models FindModels(int id);
    }
}
