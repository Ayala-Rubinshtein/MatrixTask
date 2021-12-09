import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { user } from '../Classes/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  // ,"proxyConfig": "proxy.conf.json"
  
constructor(private http:HttpClient) { }
// url="https://voicespaceserver.azurewebsites.net/api/User/"
url="api/User/";
// url="https://vizel.azurewebsites.net/api/User/";
// "target": "https://localhost:44306/",


user:user


getUserByUserNameAndPassword(userName:string, password:string):Observable<user>
{
  let userData={userName:userName,password:password}
debugger
  return this.http.post<user>(this.url+"GetUserByUserNameAndPassword",userData)
}
addUser(u:user):Observable<user>
{
  debugger
  return this.http.post<user>(this.url+"AddUser",u)

}
}
