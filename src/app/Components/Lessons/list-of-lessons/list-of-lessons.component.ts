import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LessonService } from 'src/app/Services/lesson.service';
import { MagidService } from 'src/app/Services/magid.service';
import { UpdateLessonComponent } from '../update-lesson/update-lesson.component';


export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}





@Component({
  selector: 'date-pipe',
  templateUrl: './list-of-lessons.component.html',
  styleUrls: ['./list-of-lessons.component.css']
})
export class ListOfLessonsComponent implements OnInit {

  constructor(public lessonServ:LessonService,public magidServ:MagidService,public dialog: MatDialog) { }
  displayedColumns: string[] = ['magid','number', 'name', 'beginDate','edit'];
  dataSource=[] ;
  ngOnInit(): void {
    this.lessonServ.getAllLessonss().subscribe(data=>{ this.dataSource=data ;debugger;},er=>{})
      // this.magidServ.getAllMagids().subscribe(data=>{ var list=data 
      // this.dataSource.forEach(f=>f.idmagid=list)
      // debugger;
      // }, er=>{})
  debugger;
  }
  openEdit(Lesson)
  {
    debugger
    const dialogRef = this.dialog.open(UpdateLessonComponent, {
      disableClose: true,
      width: '50%',
      data: {lesson:Lesson},
    });

    dialogRef.afterClosed().subscribe(result => {
      debugger
      console.log('The dialog was closed');
    
    });
  }

}
