import { Component, OnInit } from '@angular/core';
import { MakeService } from '../services/make.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: any = {}

  constructor(private makeService: MakeService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(data => this.makes = data)
    //debugger
  }
  onMakeChange(){
    //console.log("vehicle", this.vehicle)
    let selectedMake = this.makes.find(m => m.id == this.vehicle.make)
    //console.log(selectedMake)
    this.models = selectedMake ? selectedMake.models : []
  }

}
