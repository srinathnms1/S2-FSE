import { Component, OnInit } from '@angular/core';
import { BookingService } from './booking.service';
import { Title } from '@angular/platform-browser';
import { TripInfoViewModel, UpdateBookingViewModel, TripInfoUpdateViewModel } from 'src/api-client/booking/api-types';
import { AuthService } from '../services/auth.service';
import { UserType } from '../registration/User';
import { TripStatus } from './booking';

@Component({
  selector: 'app-trip-summary',
  templateUrl: './trip-summary.component.html',
  styleUrls: ['./trip-summary.component.css']
})
export class TripSummaryComponent implements OnInit {

  trips: TripInfoViewModel[];

  isCustomer: boolean;

  constructor(
    private bookingService: BookingService,
    private authService: AuthService,
    private title: Title) {
    this.isCustomer = UserType[authService.currentUserValue.userType] === UserType.Customer;
    this.title.setTitle('Online Travel Management System - Trip Summary');
  }

  ngOnInit() {
    this.get();
  }

  get() {
    this.bookingService.get(this.authService.currentUserValue.id)
      .then((trips: TripInfoViewModel[]) => {
        this.trips = trips;
      });
  }

  onStart(tripId: string) {
    const tripInfoUpdateViewModel: TripInfoUpdateViewModel = {
      tripId,
      status: TripStatus.InProgress
    };

    this.bookingService.updateBookingTripInfo(tripInfoUpdateViewModel).
      then((isSuccess: boolean) => {
        if (isSuccess) {
          this.get();
        }
      });
  }

  onComplete(trip: TripInfoViewModel) {
    const updateBookingViewModel: UpdateBookingViewModel = {
      bookingId: trip.bookingId,
      tripId: trip.id,
      status: TripStatus.Completed
    };

    this.bookingService.updateBooking(updateBookingViewModel).
      then((isSuccess: boolean) => {
        if (isSuccess) {
          this.get();
        }
      });
  }

  onCancel(trip: TripInfoViewModel) {
    const updateBookingViewModel: UpdateBookingViewModel = {
      bookingId: trip.bookingId,
      tripId: trip.id,
      status: TripStatus.Cancelled
    };

    this.bookingService.updateBooking(updateBookingViewModel).
      then((isSuccess: boolean) => {
        if (isSuccess) {
          this.get();
        }
      });
  }
}
