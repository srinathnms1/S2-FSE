import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserClaim } from 'src/api-client/auth/api-types';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  isUserLoggedIn: boolean;
  constructor(private authService: AuthService) {
    this.authService.currentUser.subscribe((userClain: UserClaim) => this.isUserLoggedIn = !!userClain);
  }
}
