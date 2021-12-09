import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MagidService {

  constructor(private http:HttpClient) { }
  url="api/Magid/";
  // url="https://vizel.azurewebsites.net/api/Magid/";

  getAllMagids():Observable<Array<any>>{
    return this.http.get<Array<any>>(this.url+"GetListMagids")

  }
}
