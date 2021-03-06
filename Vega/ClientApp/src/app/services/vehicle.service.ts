import { Injectable } from '@angular/core';;
//import { map } from 'rxjs/operators/';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {
  createVehicle(vehicle) {
    return this.http.post('api/vehicles', vehicle)
  }

  constructor(private http: HttpClient) { }
  
  getMakes(): Observable<any>{
    return this.http.get('/api/Makes')
      //.pipe(map(m = m.json()))
  }
  
  getFeatures(): Observable<any> {
    return this.http.get('/api/Features')
  }
  getVehicle(id): Observable<any>{
    debugger
    return this.http.get('/api/Vehicles/' + id)
  }
}
