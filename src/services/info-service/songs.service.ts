import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { ISong } from '../../app/interfaces/songs';
import { IArtistsName } from 'src/app/interfaces/artistsname';
@Injectable({
  providedIn: 'root'
})
export class SongsService {

  SongsList: ISong[];

  constructor(private http: HttpClient) { }

  getSongs(): Observable<ISong[]> {
    let tempVar = this.http.get<ISong[]>('http://localhost:49486/api/Songs/GetTopTenSongDetails').pipe(catchError(this.errorHandler));
    return tempVar;
  }

  getArtistsOfSong(SongId: number): Observable<IArtistsName[]>
  {
    var param = "?SongId=" + SongId;
    let tempVar = this.http.get<IArtistsName[]>('http://localhost:49486/api/Songs/GetArtistsOfSong' + param).pipe(catchError(this.errorHandler));
    return tempVar;
  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }


}
