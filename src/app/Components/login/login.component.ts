import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { user } from 'src/app/Classes/user';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Route } from '@angular/compiler/src/core';
import { UserService } from 'src/app/Services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private router:Router,public userSer:UserService,private formBuilder: FormBuilder) { }

userName:string;
password:string;
registerForm: FormGroup;

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({

      passwordFC: new FormControl('', [Validators.required]),
      userNameFC: new FormControl('', [Validators.required])
    });
      }
      login()
    {

    this.userSer.getUserByUserNameAndPassword(this.userName, this.password).subscribe(
      myData => {
        if (myData == null) {
          alert("לא קיים שם משתמש וסיסמה במערכת. נא נסה שוב")
          return;
        }
        debugger
        localStorage.setItem("currentUser", JSON.stringify({ myData }));
        console.log(JSON.parse(localStorage.getItem('currentUser')).myData.FirstName);
        //console.log(myData);
        this.router.navigate(["home"]);

      },
      myErr => {
        alert("תקלה במערכת. נא נסה שוב")
        console.log(myErr);
      }
    )
    }
}
