import * as ApiCommon from "../api-common"
// @ts-ignore
import * as Types from "../api-types"

export type Get_Type = {
  userId: string
}
export type Get_Response = Types.TripInfoViewModel[]
/**
 * GET /api/trip/{userId}
 *
 **/
export const Get = ApiCommon.requestMaker<Get_Type, Get_Response>({
  id: "Get",
  path: "/api/trip/{userId}",
  verb: "GET",
  parameters: [{ name: "userId", required: true, in: "path" }]
})

export type Start_Type = {
  tripInfoUpdateViewModel?: Types.TripInfoUpdateViewModel
}
export type Start_Response = boolean
/**
 * POST /api/trip/start
 *
 **/
export const Start = ApiCommon.requestMaker<Start_Type, Start_Response>({
  id: "Start",
  path: "/api/trip/start",
  verb: "POST",
  parameters: [{ name: "tripInfoUpdateViewModel", required: false, in: "body" }]
})
