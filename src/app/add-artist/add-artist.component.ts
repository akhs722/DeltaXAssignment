import { Component, OnInit } from '@angular/core';
import { IArtist } from '../interfaces/artists';
import { ArtistsService } from 'src/services/info-service/artists.service';
import { Router,ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-add-artist',
  templateUrl: './add-artist.component.html',
  styleUrls: ['./add-artist.component.css']
})
export class AddArtistComponent implements OnInit {

  songId: number;
  ArtistList: IArtist[];
  status: number;
  email: string;
  constructor(private route: ActivatedRoute,private router:Router, private _artistservice: ArtistsService) { }

  ngOnInit() {

    if (this.email == null) {
      alert("You need to Login First")
      this.router.navigate(['/login']);
    }

    this.songId = this.route.snapshot.params['songId'];

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
  addArtist(artistId:number)
  {
    if (artistId != 0)
    {
      this._artistservice.songArtistRelation(this.songId, artistId).subscribe(
        x => {
          this.status = x;
          if (this.status == 1) {
            alert("Song and Artists Added");
          }
          else {
            alert("Try again after some time");
          }
        },
        y => {
          console.log(y);
        },
        () => console.log("method executed successfully")
      );
    }
  }
}
