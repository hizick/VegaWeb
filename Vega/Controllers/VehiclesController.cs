using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.APIResource;
using Vega.APIResource.Feature;
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
            //throw new Exception;
            var vehicleList = new Vehicle();

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //this is adding input validation and returning to the user

                var model = makes.FindModels(vehicleResource.ModelId);
                if (model == null)
                {
                    //business validation
                    ModelState.AddModelError("ModelId", "Invalid ModelId ");
                    return BadRequest(ModelState);
                }

                vehicleList.ModelId = vehicleResource.ModelId;
                vehicleList.Model = makes.FindModels(vehicleResource.ModelId);
                vehicleList.isRegistered = vehicleResource.isRegistered;
                vehicleList.ContactEmail = vehicleResource.Contact.ContactEmail;
                vehicleList.ContactName = vehicleResource.Contact.ContactName;
                vehicleList.ContactPhone = vehicleResource.Contact.ContactPhone;
                vehicleList.Features = getVehicleFeatures(vehicleResource.Features);
                vehicleList.LastUpdated = now;
                vehicle.AddVehicle(vehicleList);
            }
            catch (Exception ex)
            {
                return null;
            }
            return CreatedAtAction("GetVehicles", new { id = vehicleList.Id }, vehicleResource);
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
            
            var vehicleData = new VehicleData();
            var conPairModels = new ConstantPair();
            var conPairMakes = new ConstantPair();

            var vehicleList = vehicle.GetVehicleById(id);

            var vmodels = makes.FindModels(vehicleList.ModelId);
            conPairModels.Id = vmodels.Id;
            conPairModels.Name = vmodels.Name;

            var vmakes = makes.GetMakeById(vmodels.Make.Id);
            conPairMakes.Id = vmakes.Id;
            conPairMakes.Name = vmakes.Name;


            var cont = new ContactResource();
            cont.ContactEmail = vehicleList.ContactEmail;
            cont.ContactName = vehicleList.ContactName;
            cont.ContactPhone = vehicleList.ContactPhone;
            vehicleData.Features = getFeatures(vehicleList.Features);
            vehicleData.isRegistered = vehicleList.isRegistered;
            vehicleData.LastUpdated = vehicleList.LastUpdated;
            vehicleData.Contact = cont;
            vehicleData.Model = conPairModels;
            vehicleData.Make = conPairMakes;
            return Ok(vehicleData);
        }

        public ICollection<ConstantPair> getFeatures(ICollection<VehicleFeature> vehicleFeatures)
        {
            ICollection<ConstantPair> intList = new Collection<ConstantPair>();

            foreach (var item in vehicleFeatures)
            {
                ConstantPair featureResource = new ConstantPair();

                featureResource.Id = item.Feature.Id;
                featureResource.Name = item.Feature.Name;
                intList.Add(featureResource);
            }
            return intList;
        }

        public ICollection<VehicleFeature> getVehicleFeatures(ICollection<int> features)
        {
            ICollection<VehicleFeature> vfList = new Collection<VehicleFeature>();
            foreach (var item in features)
            {
                VehicleFeature vfeature = new VehicleFeature();

                var vfeatureS = vehicle.GetVehicleFeatureByFeatureId(item);
                vfeature.Feature = vfeatureS.Feature;
                vfeature.FeatureId = vfeatureS.FeatureId;
                vfList.Add(vfeature);
            }
            return vfList;
        }
        //where you stopped: contemplating about changing feature integer to feature object in the vehicle resource. Point is to get a vehicle obj as mosh
    }
}
