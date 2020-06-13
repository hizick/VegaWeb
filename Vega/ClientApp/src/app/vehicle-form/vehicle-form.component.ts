import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];
  vehicle: any = {
    features: [],//<[]>[],
    contact: <{}>{}
  }

  constructor(private vehicleService: VehicleService, 
              private toastr: ToastrService,
              private router: Router,
              private route: ActivatedRoute) {

                route.params.subscribe(
                  p => {
                    this.vehicle.id = +p["id"];
                  }
                )
               }

  ngOnInit() {
    this.vehicleService.getVehicle(this.vehicle.id).subscribe(data => this.vehicle = data)
    this.vehicleService.getMakes().subscribe(data => this.makes = data)
    this.vehicleService.getFeatures().subscribe(data => this.features = data)
    //debugger
  }
  onMakeChange(){
    //console.log("vehicle", this.vehicle)
    let selectedMake = this.makes.find(m => m.id == this.vehicle.makeId)
    //console.log(selectedMake)
    this.models = selectedMake ? selectedMake.models : []
    delete this.vehicle.modelId
  }

  onFeatureToggle(featureId, $event) {
    if ($event.target.checked) {
      this.vehicle.features.push(featureId)
    }
    else{
      let index = this.vehicle.features.indexOf(featureId);
      this.vehicle.features.splice(index, 1)
    }
  }

  createVehicle(){
    this.vehicle.id = 0;
    this.vehicleService.createVehicle(this.vehicle)
    .subscribe(
      data =>  {
        this.toastr.success(
          "Vehicle added successfully",
          "Success"
        )
      })
  }

}
