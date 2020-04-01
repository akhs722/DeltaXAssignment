import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-user-layout',
  templateUrl: './user-layout.component.html',
  styleUrls: ['./user-layout.component.css']
})
export class UserLayoutComponent implements OnInit {

  email: string;

  constructor(private _router: Router) { }

  ngOnInit() {

    this.email = sessionStorage.getItem('userEmail'); 
  }
  logOut() {
    sessionStorage.removeItem('userEmail');
    this._router.navigate(['']);
  }
}
