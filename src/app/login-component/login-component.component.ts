import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../services/user-service/user.service';
@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css']
})
export class LoginComponentComponent implements OnInit {

  status: string;
  errorMsg: string;
  msg: string;
  showDiv: boolean = false;
  constructor(private _userService: UserService,private router:Router) { }

  submitLoginForm(form: NgForm) {

    this._userService.ValidateUserCredentials(form.value.email, form.value.password).subscribe(
      x => {
        this.status = x;
        this.showDiv = true;
        if (this.status.toLowerCase() != "invalid credentials") {
          sessionStorage.setItem('userEmail', form.value.email);
          this.router.navigate(['/home']);
       }
        else {
          alert("Try again with valid credentials");
        }
      },
      y => {
        console.log(y)
      },
      () => console.log("method executed successfully")
    );

  }
  ngOnInit() {
  }
}
