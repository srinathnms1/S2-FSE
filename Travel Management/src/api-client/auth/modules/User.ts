import * as ApiCommon from "../api-common"
// @ts-ignore
import * as Types from "../api-types"

export type Post_Type = {
  registrationViewModel?: Types.RegistrationViewModel
}
export type Post_Response = string
/**
 * POST /api/user/registration
 *
 **/
export const Post = ApiCommon.requestMaker<Post_Type, Post_Response>({
  id: "Post",
  path: "/api/user/registration",
  verb: "POST",
  parameters: [{ name: "registrationViewModel", required: false, in: "body" }]
})

export type Get_Type = {}
export type Get_Response = Types.UserViewModel[]
/**
 * GET /api/user/employees
 *
 **/
export const Get = ApiCommon.requestMaker<Get_Type, Get_Response>({
  id: "Get",
  path: "/api/user/employees",
  verb: "GET",
  parameters: []
})
