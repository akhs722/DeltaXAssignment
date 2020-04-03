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

  songId: number;
  fileToUpload: File = null;
  rating: number = 0;
  email: string;
  constructor(private _userService:UserService,private router: Router) { }


  ngOnInit() {
    this.email = sessionStorage.getItem('userEmail');
    if (this.email == null) {
      alert("You need to Login First")
      this.router.navigate(['/login']);
    }

  }

  setRating($event) {

    this.rating = $event.rating;
    alert(this.rating)
  }

  addSong(form: NgForm)
  {
    this._userService.AddSong(form.value.songname, form.value.release, this.rating, "later").subscribe(
      x => {
        this.songId = x;
        if (this.songId >= 10000) {
          this.router.navigate(['/addartist',this.songId]);
          
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

  handleFile(file: FileList)
  {
    this.fileToUpload = file.item(0);
  }
}
