import { Component, OnInit, Input } from '@angular/core';
import { TripInfoViewModel } from 'src/api-client/booking/api-types';

@Component({
  selector: 'app-booking-details',
  templateUrl: './booking-details.component.html',
  styleUrls: ['./booking-details.component.css']
})
export class BookingDetailsComponent implements OnInit {

  @Input() tripInfoViewModel: TripInfoViewModel;

  constructor() { }

  ngOnInit() {
  }

}
