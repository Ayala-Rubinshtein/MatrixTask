import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
constructor(private http:HttpClient) { }
  url="api/Lesson/";
  // url="https://vizel.azurewebsites.net/api/Lesson/";

  uploadLesson(Name:string,BeginDate:string,Length:number,SchoolID:number,MagidID:number):Observable<boolean>{
  debugger
    return this.http.get<boolean>(this.url+"AddLesson/"+Name+"/"+BeginDate+"/"+Length+"/"+SchoolID+"/"+MagidID)
  }
  updateLesson(Name:string,BeginDate:string,Length:number,SchoolID:number,MagidID:number):Observable<boolean>
  {
    debugger
    return this.http.get<boolean>(this.url+"UpdateLesson/"+Name+"/"+BeginDate+"/"+Length+"/"+SchoolID+"/"+MagidID)
  }



 UploadAudioFileToExt(fileToUpload: File, extPath: string, fileName: string):Observable<any>{
    debugger


    let formdata: FormData = new FormData();
    debugger
    let fd: FormData = new FormData();
    fd.append("file", fileToUpload)
    fd.append("token", "0733638677:111222")     //mosad.VoiceSystemPhone + ":" + mosad.Password)// mosad.VoiceSystemPhone + ':' + mosad.Password)
    debugger;
    if(fileName==null)
    fd.append("path", extPath)
    else
    fd.append("path", "ivr2:/"+extPath + '/' + fileName)
    fd.append("convertAudio", '1')
    let urlstart:string="";
    urlstart = "https://private."
debugger
   // return this.http.post(urlstart+"call2all.co.il/ym/api/UploadFile", fd)//, { headers: { 'Content-Type': 'multipart/form-data' } })
    // return this.http.post(this.url + "UploadFileToIVR", fd, { headers: { 'Content-Type': 'multipart/form-data' } })
    return this.http.post("https://private.call2all.co.il/ym/api/UploadFile",fd)
  }
  getAllLessonss():Observable<Array<any>>{
    return this.http.get<Array<any>>(this.url+"GetAllLessons/6")

  }
}