import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserClaim } from 'src/api-client/auth/api-types';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public currentUserSubject: BehaviorSubject<UserClaim>;
  public currentUser: Observable<UserClaim>;
  constructor(private http: HttpClient) {
    this.currentUserSubject = new BehaviorSubject<UserClaim>(JSON.parse(localStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): UserClaim {
    return this.currentUserSubject.value;
  }
}
