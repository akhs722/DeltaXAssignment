import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { IArtist } from '../../app/interfaces/artists';
import { ISongArtistRelation } from 'src/app/interfaces/songartistrelation';
@Injectable({
  providedIn: 'root'
})
export class ArtistsService {
  ArtistsList: IArtist[];

  constructor(private http: HttpClient) { }

  getArtists(): Observable<IArtist[]> {
    let tempVar = this.http.get<IArtist[]>('http://localhost:49486/api/Artists/GetTopTenArtistDetails').pipe(catchError(this.errorHandler));
    return tempVar;
  }

  songArtistRelation(songId:number,artistId:number) {
    var userObj: ISongArtistRelation;
    userObj = { songId: songId, artistId: artistId};
    return this.http.post<number>('http://localhost:49486/api/Artists/SongArtistRelation', userObj).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }

}
