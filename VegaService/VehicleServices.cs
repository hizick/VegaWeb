﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VegaData.Models;
using VegaData.Models.Context;
using VegaData.Repositories;

namespace VegaService
{
    public class VehicleServices : IVehicles
    {
        private VegaDbContext context;
        public VehicleServices(VegaDbContext _context)
        {
            context = _context;
        }
        public void AddVehicle(Vehicle vehicle)
        {
                context.Vehicles.Add(vehicle);
                context.SaveChanges();
        }

        //public Vehicle GetVehicle(int id) => context.Vehicles.FirstOrDefault(v => v.Id == id);

        public Vehicle GetVehicleById(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return context.Vehicles.FirstOrDefault(v => v.Id == id);
            var vv = context.Vehicles
              .Include(vf => vf.Features)
              .ThenInclude(v => v.Feature)
              .Include(v => v.Model)
              .ThenInclude(m => m.Make)
              .FirstOrDefault(v => v.Id == id);
            return vv;
        }

        public void Remove(Vehicle vehicle) => context.Remove(vehicle);

        public VehicleFeature GetVehicleFeatureByFeatureId(int id)
        {
            var vehicleFeature = context.VehicleFeatures.FirstOrDefault(x => x.FeatureId == id);
            return vehicleFeature;
        }
    }
}
