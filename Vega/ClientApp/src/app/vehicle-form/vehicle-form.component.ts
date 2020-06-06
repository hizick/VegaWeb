import { Component, OnInit } from '@angular/core';
import { MakeService } from '../services/make.service';
import { Observable } from 'rxjs';
import { FeatureService } from '../services/feature.service';

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

  constructor(private makeService: MakeService, private featureService: FeatureService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(data => this.makes = data)
    this.featureService.getFeatures().subscribe(data => this.features = data)
    //debugger
  }
  onMakeChange(){
    //console.log("vehicle", this.vehicle)
    let selectedMake = this.makes.find(m => m.id == this.vehicle.make)
    //console.log(selectedMake)
    this.models = selectedMake ? selectedMake.models : []
  }

}
