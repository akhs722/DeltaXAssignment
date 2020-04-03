import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {

  @Input() rating: number;
  @Input() songId: number;
  @Output() ratingClick: EventEmitter<any> = new EventEmitter<any>();
  inputName:string
  // @Output() ratingEvent = new EventEmitter<number>();;
  constructor() {
   
  }

  ngOnInit() {
    this.inputName = "a" + this.songId;
  }

  onClick(rating: number){

    this.rating = rating;
    this.ratingClick.emit({
      songId: this.songId,
      rating: rating
    });
  }
}
