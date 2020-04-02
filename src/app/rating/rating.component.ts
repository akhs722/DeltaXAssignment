import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.css']
})
export class RatingComponent implements OnInit {

  rating: number
  @Output() ratingEvent = new EventEmitter<number>();
  constructor() { }

  ngOnInit() {
  }

  onClick(rating: number){

    this.rating = rating;
    this.ratingEvent.emit(this.rating)
  }
}
