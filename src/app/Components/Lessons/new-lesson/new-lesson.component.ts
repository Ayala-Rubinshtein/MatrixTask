import { Component, OnInit } from '@angular/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {FormControl} from '@angular/forms';
import {TooltipPosition} from '@angular/material/tooltip';
import { MagidService } from 'src/app/Services/magid.service';
import { LessonService } from 'src/app/Services/lesson.service';
import { __values } from 'tslib';
import { HttpClient } from '@angular/common/http';
import { ok } from 'assert';
import { NgxUiLoaderService } from 'ngx-ui-loader';


@Component({
  selector: 'app-new-lesson',
  templateUrl: './new-lesson.component.html',
  styleUrls: ['./new-lesson.component.css']
})
export class NewLessonComponent implements OnInit {

  constructor(public magidServ:MagidService,public LessonServ:LessonService, private http: HttpClient,private ngxService: NgxUiLoaderService,
    ) { }
  positionOptions: TooltipPosition[] = [] ;
  file: File;
  duration:number = 0;
  name:string;
  // date:Date=new Date();
  date = new FormControl();
  // = ['below', 'above', 'left', 'right'];
  position:FormControl;
  ngOnInit(): void {
   this.magidServ.getAllMagids().subscribe(data=>{ var list=data 
    debugger;
    
list.forEach(f=> this.positionOptions.push(f))
    this.position = new FormControl();
}, er=>{})
  }
  
  handleFileInput(files: FileList) {
    this.file = files[0];
    new Audio(URL.createObjectURL(this.file)).onloadedmetadata = (e:any) =>{
        this.duration = e.currentTarget.duration;
    }
}
formatDate(date) {
  let month = date.getMonth() + 1;
  let day = date.getDate();

  if (month < 10) {
    month = '0' + month;
  }

  if (day < 10) {
    day = '0' + day;
  }

  return day + '-' + month + '-' + date.getFullYear();
}
uploadLesson(){
  debugger
  this.ngxService.start();
  var date=this.formatDate(this.date.value)
  var name=this.position.value.idmagid+"-"+date
  let x=this.LessonServ.uploadLesson(this.name,date,this.duration,6,this.position.value.idmagid).subscribe(d=>{
    if(d==false)
    {
      debugger
      alert('כבר קיים שיעור למגיד זה בתאריך המבוקש.');
      this.ngxService.stop();
      return
    }
    this.LessonServ.UploadAudioFileToExt(this.file,"12341234",name).subscribe(d=>{ 
      debugger
      if(d.responseStatus=="OK")
      {
        debugger
        alert("השיעור הועלה בהצלחה")
        this.date=new FormControl()
        this.position=new FormControl()
        this.file=undefined
      }
      else
      {
        alert("אירעה שגיאה אנא נסה שוב")
      }
      this.ngxService.stop();
    },er=>{debugger})
  }
  ,er=>{});
}
}
