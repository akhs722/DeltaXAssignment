import { Component, OnInit } from '@angular/core';
import { IArtist } from '../interfaces/artists';
import { ArtistsService } from 'src/services/info-service/artists.service';
import { Router,ActivatedRoute, Data } from '@angular/router';
import { and } from '@angular/router/src/utils/collection';
import { UserService } from 'src/services/user-service/user.service';
import { IArtistStructure } from '../interfaces/artist';

@Component({
  selector: 'app-add-artist',
  templateUrl: './add-artist.component.html',
  styleUrls: ['./add-artist.component.css']
})
export class AddArtistComponent implements OnInit {

  showDiv: boolean = false;
  flag: number;
  songId: number;
  ArtistList: IArtistStructure[];
  status: number;
  email: string;
  constructor(private route: ActivatedRoute,private router:Router, private _artistservice: ArtistsService,private _userservice:UserService) { }

  ngOnInit() {
    this.email = sessionStorage.getItem('userEmail');
    if (this.email == null) {
      alert("You need to Login First")
      this.router.navigate(['/login']);
    }

    this.songId = this.route.snapshot.params['songId'];

    this._artistservice.getAllArtists().subscribe(
      x => {
        this.ArtistList = x;
      },
      y => {
        console.log(y);
      },
      () => console.log("Success")
    );
  }
  addArtist(artistId:number)
  {
    if (artistId > 99) {
      this._artistservice.songArtistRelation(this.songId, artistId).subscribe(
        x => {
          this.status = x;
          if (this.status == 1) {
            alert("Song and Artists Added");
          }
          else {
            alert("Try again after some time");
            this.ngOnInit()
          }
        },
        y => {
          console.log(y);
        },
        () => console.log("method executed successfully")
      );
    }
    else if (artistId == 6) {
      this.showDiv = true;
    }
    else
    {
      this.showDiv = false;
    }
  }

  addNewArtist(name: string, date: Date, bio: string)
  {
    this._userservice.AddArtist(name, date,bio).subscribe(
      x => {
        this.flag = x;
        if (this.flag == 1) {
          alert("Artist added now choose from the dropdown.");
          this.ngOnInit()
        }
        else {
          alert("Try again after some time");
          this.ngOnInit()
        }
      },
      y => {
        console.log(y);
      },
      () => console.log("method executed successfully")
    );
  }


}
