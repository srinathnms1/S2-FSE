import { Component, OnInit } from '@angular/core';
import { BookingViewModel, AcceptBookingViewModel, UpdateBookingViewModel } from 'src/api-client/booking/api-types';
import { BookingService } from '../booking.service';
import { AuthService } from 'src/app/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { UserType } from 'src/app/registration/User';
import { BookingStatus } from '../booking';

@Component({
  selector: 'app-upcomming-trip',
  templateUrl: './upcomming-trip.component.html',
  styleUrls: ['./upcomming-trip.component.css']
})
export class UpcommingTripComponent implements OnInit {

  constructor(private bookingService: BookingService, private authService: AuthService, private toastr: ToastrService) { }

  bookings: BookingViewModel[];
  isCustomer = this.authService.currentUserValue.userType === UserType[UserType.Customer];

  ngOnInit() {
    this.getBookings();
  }

  getBookings() {
    this.bookingService.getBookings(this.authService.currentUserValue.id)
      .then((bookings: BookingViewModel[]) => this.bookings = bookings);
  }

  onAccept(bookingId: string) {
    const acceptBookingViewModel: AcceptBookingViewModel = {
      bookingId,
      driverId: this.authService.currentUserValue.id
    };
    this.bookingService.acceptBooking(acceptBookingViewModel)
      .then((isSuccess: boolean) => {
        if (isSuccess) {
          this.getBookings();
          this.toastr.success('Booking accepted successfully.');
        }
      });
  }

  onCancel(bookingId: string) {
    const updateBookingViewModel: UpdateBookingViewModel = {
      bookingId,
      status: BookingStatus.Cancelled
    };
    this.bookingService.updateBooking(updateBookingViewModel);
  }

}
