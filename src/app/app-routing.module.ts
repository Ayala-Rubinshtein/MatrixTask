import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { NewLessonComponent } from './Components/Lessons/new-lesson/new-lesson.component';
import {ListOfLessonsComponent} from './Components/Lessons/list-of-lessons/list-of-lessons.component'
import { LoginComponent } from './Components/login/login.component';



const routes: Routes = [{ path: '', redirectTo: 'Login', pathMatch: 'full' },
{ path: 'Login', component: LoginComponent },
{ path:'home',component:HomeComponent, children:
[
  { path: 'UploadFileLesson',component:NewLessonComponent},
  { path: 'allLessons',component:ListOfLessonsComponent}

]},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}
