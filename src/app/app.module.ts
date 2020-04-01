import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponentComponent } from './login-component/login-component.component';
import { routing } from './app.routing';
import { HomeComponent } from './home/home.component';
import { CommonLayoutComponent } from './common-layout/common-layout.component';
import { UserLayoutComponent } from './user-layout/user-layout.component';
import { AddSongComponent } from './add-song/add-song.component';
import { AddArtistComponent } from './add-artist/add-artist.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponentComponent,
    HomeComponent,
    CommonLayoutComponent,
    UserLayoutComponent,
    AddSongComponent,
    AddArtistComponent,
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    routing
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
