import * as ApiCommon from "../api-common"
// @ts-ignore
import * as Types from "../api-types"

export type PendingBookings_Type = {}
export type PendingBookings_Response = Types.BookingViewModel[]
/**
 * GET /api/booking/pending
 *
 **/
export const PendingBookings = ApiCommon.requestMaker<
  PendingBookings_Type,
  PendingBookings_Response
>({
  id: "PendingBookings",
  path: "/api/booking/pending",
  verb: "GET",
  parameters: []
})

export type PendingCustomerBookings_Type = {
  userId: string
}
export type PendingCustomerBookings_Response = Types.BookingViewModel[]
/**
 * GET /api/booking/{userId}
 *
 **/
export const PendingCustomerBookings = ApiCommon.requestMaker<
  PendingCustomerBookings_Type,
  PendingCustomerBookings_Response
>({
  id: "PendingCustomerBookings",
  path: "/api/booking/{userId}",
  verb: "GET",
  parameters: [{ name: "userId", required: true, in: "path" }]
})

export type CreateBooking_Type = {
  bookingViewModel?: Types.BookingViewModel
}
export type CreateBooking_Response = boolean
/**
 * POST /api/booking/create
 *
 **/
export const CreateBooking = ApiCommon.requestMaker<CreateBooking_Type, CreateBooking_Response>({
  id: "CreateBooking",
  path: "/api/booking/create",
  verb: "POST",
  parameters: [{ name: "bookingViewModel", required: false, in: "body" }]
})

export type AcceptBooking_Type = {
  acceptBookingViewModel?: Types.AcceptBookingViewModel
}
export type AcceptBooking_Response = boolean
/**
 * PUT /api/booking/accept
 *
 **/
export const AcceptBooking = ApiCommon.requestMaker<AcceptBooking_Type, AcceptBooking_Response>({
  id: "AcceptBooking",
  path: "/api/booking/accept",
  verb: "PUT",
  parameters: [{ name: "acceptBookingViewModel", required: false, in: "body" }]
})

export type UpdateBooking_Type = {
  updateBookingViewModel?: Types.UpdateBookingViewModel
}
export type UpdateBooking_Response = boolean
/**
 * PUT /api/booking/update
 *
 **/
export const UpdateBooking = ApiCommon.requestMaker<UpdateBooking_Type, UpdateBooking_Response>({
  id: "UpdateBooking",
  path: "/api/booking/update",
  verb: "PUT",
  parameters: [{ name: "updateBookingViewModel", required: false, in: "body" }]
})
