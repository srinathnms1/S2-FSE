import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { BaseService } from '../services/base.service';
import { BookingViewModel, TripInfoViewModel, AcceptBookingViewModel, UpdateBookingViewModel, TripInfoUpdateViewModel } from 'src/api-client/booking/api-types';
import { Get, Start } from 'src/api-client/booking/modules/Trip';
import {
  CreateBooking, PendingBookings, PendingCustomerBookings, UpdateBooking, AcceptBooking
} from 'src/api-client/booking/modules/Booking';
import { UserType } from '../registration/User';

@Injectable({
  providedIn: 'root'
})
export class BookingService extends BaseService {

  constructor(private http: HttpClient, private authService: AuthService) {
    super(authService);
  }

  get(userId: string): Promise<TripInfoViewModel[]> {
    return Get({ userId });
  }

  getBookings(userId: string): Promise<BookingViewModel[]> {
    const { userType } = this.authService.currentUserValue;
    if (userId === UserType[UserType.Customer]) {
      return PendingCustomerBookings({ userId });
    }
    return PendingBookings({});
  }

  save(bookingViewModel: BookingViewModel): Promise<boolean> {
    return CreateBooking({ bookingViewModel });
  }

  acceptBooking(acceptBookingViewModel: AcceptBookingViewModel): Promise<boolean> {
    return AcceptBooking({ acceptBookingViewModel });
  }

  updateBooking(updateBookingViewModel: UpdateBookingViewModel): Promise<boolean> {
    return UpdateBooking({ updateBookingViewModel });
  }

  updateBookingTripInfo(tripInfoUpdateViewModel: TripInfoUpdateViewModel): Promise<boolean> {
    return Start({ tripInfoUpdateViewModel });
  }
}
