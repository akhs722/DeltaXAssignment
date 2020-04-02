import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { IUser } from '../../app/interfaces/user';
import { IRating } from '../../app/interfaces/rating';
import { ISong } from '../../app/interfaces/songs';
import { IArtistStructure } from 'src/app/interfaces/artist';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  ValidateUserCredentials(email: string, password: string) {
    var userObj: IUser;
    userObj = { userid: 0, email: email, name: null, password: password };
    return this.http.post<boolean>('http://localhost:49486/api/User/ValidateUserCredentials', userObj).pipe(catchError(this.errorHandler));
  }

  UpdateRating(emailId: string, songid: number, rating: number): Observable<number> {
    var ratingObj: IRating;
    ratingObj = { Email: emailId, SongId: songid, rating: rating };
    return this.http.put<number>('http://localhost:49486/api/User/Rating', ratingObj).pipe(catchError(this.errorHandler));
  }
  AddSong(songName: string, dateOfRelease: Date, averageRating: number, imageCoverLocation: string): Observable<number>
  {
    var songObj: ISong;
    songObj = { songId: 0, songName: songName, dateOfRelease: dateOfRelease, averageRating: averageRating, imageCoverLocation: imageCoverLocation};
    return this.http.post<number>('http://localhost:49486/api/User/AddSong',songObj).pipe(catchError(this.errorHandler));
  }
  AddArtist(artistName: string, dateOfbirth: Date, bio: string): Observable<number> {
    var artistObj: IArtistStructure;
    artistObj = { artistId: 0, artistName: artistName, dateOfBirth: dateOfbirth, bio: bio};
    return this.http.post<number>('http://localhost:49486/api/User/AddArtist', artistObj).pipe(catchError(this.errorHandler));
  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }

}
