import { RouterModule, Routes } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { LoginComponentComponent } from './login-component/login-component.component';
import { HomeComponent } from './home/home.component';
import { AddSongComponent } from './add-song/add-song.component';
import { AddArtistComponent } from './add-artist/add-artist.component';
import { RatingComponent } from './rating/rating.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponentComponent },
  { path: 'home', component: HomeComponent },
  { path: 'addsong', component: AddSongComponent },
  { path: 'addartist/:songId', component: AddArtistComponent },
  { path: 'rating', component: RatingComponent },
  { path: '**', component: HomeComponent  }
];
export const routing: ModuleWithProviders = RouterModule.forRoot(routes);

