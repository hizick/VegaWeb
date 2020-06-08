using System;
using System.Collections.Generic;
using System.Text;
using VegaData.Models;

namespace VegaData.Repositories
{
    public interface IVehicles
    {
        void AddVehicle(Vehicle vehicle);
        Vehicle GetVehicleById(int id, bool includeRelated = true);
        void Remove(Vehicle vehicle);
    }
}
