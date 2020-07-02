import * as ApiCommon from "../api-common"
// @ts-ignore
import * as Types from "../api-types"

export type Post_Type = {
  vehicleViewMode?: Types.VehicleViewModel
}
export type Post_Response = string
/**
 * POST /api/vehicle
 *
 **/
export const Post = ApiCommon.requestMaker<Post_Type, Post_Response>({
  id: "Post",
  path: "/api/vehicle",
  verb: "POST",
  parameters: [{ name: "vehicleViewMode", required: false, in: "body" }]
})
