import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  features: any[];
  vehicle: any = {}

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(data => this.makes = data)
    this.vehicleService.getFeatures().subscribe(data => this.features = data)
    //debugger
  }
  onMakeChange(){
    //console.log("vehicle", this.vehicle)
    let selectedMake = this.makes.find(m => m.id == this.vehicle.make)
    //console.log(selectedMake)
    this.models = selectedMake ? selectedMake.models : []
  }

}
