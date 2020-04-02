import { Component, OnInit } from '@angular/core';
import { ISong } from '../../app/interfaces/songs';
import { IArtist } from '../interfaces/artists';
import { IArtistsName } from 'src/app/interfaces/artistsname';
import { SongsService } from 'src/services/info-service/songs.service';
import { ArtistsService } from 'src/services/info-service/artists.service';
import { UserService } from 'src/services/user-service/user.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  email: string;
  SongList: ISong[];
  ArtistList: IArtist[];
  Artists: IArtistsName[];
  rating: number = 0;
  str: string = "";
  NewRating: number = 0;
  status: number;
  userLayout: boolean = false;
  commonLayout: boolean = false;
  constructor(private _userservice: UserService,private _songservice: SongsService, private _artistservice: ArtistsService) { }
  ngOnInit() {

    this.email = sessionStorage.getItem('userEmail');
    if (this.email == null) {
      this.commonLayout = true;
    }
    else
    {
      this.userLayout = true;
    }
    this._songservice.getSongs().subscribe(
      x => {
        this.SongList = x;
      },
      y => {
        console.log(y);
      },
      () => console.log("Success")
    );

    this._artistservice.getArtists().subscribe(
      x => {
        this.ArtistList = x;
      },
      y => {
        console.log(y);
      },
      () => console.log("Success")
    );
  }

  setRating($event) {

    this.rating = $event;

  }

  Rate(song: ISong) {

    if (this.rating != 0) {
      if (this.email == null) {
        alert('Login First');
      }
      else {
        this.NewRating = this.rating;      
        this._userservice.UpdateRating(this.email, song.songId, this.NewRating).subscribe(
          x => {
            this.status = x;
            if (this.status != 1) {
              alert('Try After SomeTime')
            }
          },
          y => {
             console.log(y);
              },
          () => console.log("Success")
        );
      }
    }
  }

  GetArtistsOfSong(SongId:number){

    this._songservice.getArtistsOfSong(SongId).subscribe(
      x => {
        this.Artists = null;
        this.Artists = x;
      },
      y => {
        console.log(y);
      },
      () => console.log("Success")
    );
    return SongId;
  }
 
}
