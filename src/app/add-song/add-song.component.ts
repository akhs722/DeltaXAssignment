import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/services/user-service/user.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-add-song',
  templateUrl: './add-song.component.html',
  styleUrls: ['./add-song.component.css']
})
export class AddSongComponent implements OnInit {

  status: number;
  constructor(private _userService:UserService,private router: Router) { }


  ngOnInit() {
  }
  addSong(form: NgForm)
  {
    this._userService.AddSong(form.value.songname, form.value.release, form.value.rating, form.value.image).subscribe(
      x => {
        this.status = x;
        if (this.status >= 10000) {
          this.router.navigate(['/addartist', status]);
          
        }
        else {
          alert("Try again with valid credentials");
        }
      },
      y => {
        console.log(y);
      },
      () => console.log("method executed successfully")
    );
  }
}
