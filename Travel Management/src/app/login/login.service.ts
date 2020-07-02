import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from 'src/api-client/auth/modules/Login';
import { LoginViewModel, UserClaim } from 'src/api-client/auth/api-types';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) {  }

  login(loginViewModel: LoginViewModel): Promise<UserClaim> {
    return Post({loginViewModel});
  }
}
