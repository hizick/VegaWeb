using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Vega.APIResource.Vehicle;
using VegaData.Models;
using VegaData.Repositories;

namespace Vega.Controllers
{
    [Route("/api/Vehicles")]
    public class VehiclesController : Controller
    {
        public DateTime now = DateTime.Now.Date;
        private readonly IVehicles vehicle;
        private readonly IMakes makes;
        private readonly IUnitOfWork unitOfWork;

        public VehiclesController(IMapper _mapper, IVehicles vehicle, IMakes makes, IUnitOfWork unitOfWork)
        {
            mapper = _mapper;
            this.vehicle = vehicle;
            this.makes = makes;
            this.unitOfWork = unitOfWork;
        }

        public IMapper mapper { get; }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //this is adding input validation and returning to the user

            var model = makes.FindModels(vehicleResource.ModelId);
            if (model == null)
            {
                //this is called business validation
                ModelState.AddModelError("ModelId", "Invalid ModelId ");
                return BadRequest(ModelState);
            }

            var vehicleList = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicleList.LastUpdated = now;
            vehicle.AddVehicle(vehicleList);

            vehicleList = vehicle.GetVehicleById(vehicleList.Id);

            //var result = mapper.Map<Vehicle, VehicleResource>(vehicleList);

            return Ok(vehicleList);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); //this is adding input validation and returning to the user

            var vehicleList = vehicle.GetVehicleById(id);
            if (vehicleList == null)
            {
                return NotFound();
            }
            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicleList);
            vehicleList.LastUpdated = now;
            unitOfWork.saveChanges();

            //var result = mapper.Map<Vehicle, VehicleResource>(vehicleList);

            return Ok(vehicleList);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicleList = vehicle.GetVehicleById(id, false);
            if (vehicleList == null)
                return NotFound();
            vehicle.Remove(vehicleList);
            unitOfWork.saveChanges();
            return Ok(id);
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicles(int id)
        {
            var vehicleList = vehicle.GetVehicleById(id);
            if (vehicleList == null)
                return NotFound();
            //var result = mapper.Map<Vehicle, VehicleResource>(vehicleList);
            return Ok(vehicleList);
        }
    }
}
