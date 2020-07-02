import * as ApiCommon from "../api-common"
// @ts-ignore
import * as Types from "../api-types"

export type Post_Type = {
  loginViewModel?: Types.LoginViewModel
}
export type Post_Response = Types.UserClaim
/**
 * POST /api/login
 *
 **/
export const Post = ApiCommon.requestMaker<Post_Type, Post_Response>({
  id: "Post",
  path: "/api/login",
  verb: "POST",
  parameters: [{ name: "loginViewModel", required: false, in: "body" }]
})
