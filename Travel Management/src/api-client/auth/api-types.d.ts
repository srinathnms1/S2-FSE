export interface LoginViewModel {
  username?: string
  password?: string
}

export interface UserClaim {
  id?: string
  name?: string
  mobile?: number
  token?: string
  userType?: string
  expiresIn?: number
}

export interface RegistrationViewModel {
  username?: string
  password?: string
  firstName?: string
  lastName?: string
  userType?: string
  mobile?: string
  email?: string
}

export interface UserViewModel {
  id?: string
  userType?: string
  firstName?: string
  lastName?: string
  mobile?: number
  email?: string
  name?: string
  createdOn?: string
  createdBy?: string
  updatedOn?: string
  updateddBy?: string
}
