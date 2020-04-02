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

  status: boolean;
  constructor(private _userService: UserService,private router:Router) { }

  submitLoginForm(form: NgForm) {

    this._userService.ValidateUserCredentials(form.value.email, form.value.password).subscribe(
      x => {
        this.status = x;
        
        if (this.status==true) {
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
