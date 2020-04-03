import { Component, OnInit, Input, Output,} from '@angular/core';
import { IArtistsName } from '../interfaces/artistsname';
import { SongsService } from 'src/services/info-service/songs.service';
@Component({
  selector: 'app-show-artist',
  templateUrl: './show-artist.component.html',
  styleUrls: ['./show-artist.component.css']
})
export class ShowArtistComponent implements OnInit {

  @Input() songId: number = 10003;
  Artists: IArtistsName[];
  inputName: string
  str: string;
  constructor(private _songservice: SongsService) { }

  ngOnInit() {
    this.inputName = "b" + this.songId;
  }
    GetArtistsOfSong(){
    this.str = "";
    this._songservice.getArtistsOfSong(this.songId).subscribe(
      x => {
        this.Artists = null;
        this.Artists = x;
      },
      y => {
        console.log(y);
      },
      () => console.log("Success")
    );
      for (let v of this.Artists) {
        if (this.str == "") {
          this.str = this.str + v.artistName;
        }
        else
        {
          this.str = this.str + "," + " " + v.artistName;
        }
      
      }
      return this.str;
  }

}
