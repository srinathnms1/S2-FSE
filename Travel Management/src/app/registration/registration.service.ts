import { Injectable } from '@angular/core';
import { Post } from 'src/api-client/auth/modules/User';
import { Post as createVehicle } from 'src/api-client/vehicle/modules/Vehicle';
import { RegistrationViewModel } from 'src/api-client/auth/api-types';
import { UserType } from './User';
import { VehicleViewModel } from 'src/api-client/vehicle/api-types';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {
  async createUser(registrationViewModel: RegistrationViewModel, vehicleViewMode: VehicleViewModel): Promise<string> {
    let userId = await Post({ registrationViewModel });
    if (registrationViewModel.userType === UserType[UserType.Customer]) {
      return userId;
    }
    vehicleViewMode.driverId = userId;
    userId = await createVehicle({ vehicleViewMode });
    return userId;
  }
}
