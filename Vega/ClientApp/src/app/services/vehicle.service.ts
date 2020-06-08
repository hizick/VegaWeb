import { Injectable } from '@angular/core';;
//import { map } from 'rxjs/operators/';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  constructor(private http: HttpClient) { }
  
  getMakes(): Observable<any>{
    return this.http.get('/api/Makes')
      //.pipe(map(m = m.json()))
  }
  
  getFeatures(): Observable<any> {
    return this.http.get('/api/Features')
  }
}
