export interface BookingViewModel {
  id?: string
  customerId?: string
  date?: string
  from?: string
  to?: string
  customerName?: string
  numberOfPassanger?: number
  customerMobile?: number
  status?: string
}

export interface AcceptBookingViewModel {
  driverId?: string
  bookingId?: string
}

export interface UpdateBookingViewModel {
  status?: string
  bookingId?: string
  tripId?: string
}

export interface TripInfoViewModel {
  id?: string
  bookingId?: string
  driverId?: string
  startTime?: string
  completedTime?: string
  from?: string
  to?: string
  numberOfPassanger?: number
  cost?: number
  status?: string
  createdOn?: string
}

export interface TripInfoUpdateViewModel {
  status?: string
  tripId?: string
}
