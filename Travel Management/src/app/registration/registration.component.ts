import { Component, OnInit } from '@angular/core';
import { User, Model, Brand, UserType } from './User';
import { RegistrationService } from './registration.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { RegistrationViewModel } from 'src/api-client/auth/api-types';
import { VehicleViewModel } from 'src/api-client/vehicle/api-types';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registrationForm: FormGroup;
  user: RegistrationViewModel;
  vehicle: VehicleViewModel;
  submitted = false;
  error: string;

  keys = Object.keys;
  models = Model;
  brands = Brand;

  ngOnInit(): void {
    this.registrationForm = this.formBuilder.group({
      Username: [null, Validators.compose([Validators.required, Validators.pattern('^[a-zA-Z0-9]{5,10}$')])],
      Password: [null, Validators.compose([Validators.required, Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')])],
      Firstname: [null, Validators.compose([Validators.required, Validators.maxLength(50)])],
      Lastname: [null, Validators.compose([Validators.required, Validators.maxLength(50)])],
      Mobile: [null, Validators.compose([Validators.required, Validators.pattern('^[0-9]{10}$')])],
      Email: [null, Validators.compose([Validators.required, Validators.email])],
      IsEmployee: [],
      Brand: [],
      Model: [],
      RegistrationNumber: [],
      NoOfSeats: []
    });
    this.registrationForm.valueChanges.subscribe((user: RegistrationViewModel) => this.user = user);
    this.registrationForm.valueChanges.subscribe((vehicle: VehicleViewModel) => {
      const isEmployee = this.registrationForm.get('IsEmployee');
      const brandControl = this.registrationForm.get('Brand');
      const modelControl = this.registrationForm.get('Model');
      const registrationNumberControl = this.registrationForm.get('RegistrationNumber');
      const noOfSeatsControl = this.registrationForm.get('NoOfSeats');
      if (isEmployee.value === true) {
        brandControl.setValidators([Validators.required]);
        modelControl.setValidators([Validators.required]);
        registrationNumberControl.setValidators([Validators.required]);
        noOfSeatsControl.setValidators([Validators.required]);
        this.vehicle = vehicle;
      } else {
        brandControl.setValidators(null);
        modelControl.setValidators(null);
        registrationNumberControl.setValidators(null);
        noOfSeatsControl.setValidators(null);
        this.vehicle = null;
      }
    });
  }

  constructor(
    private registrationService: RegistrationService,
    private router: Router,
    private formBuilder: FormBuilder,
    private title: Title) {
    this.title.setTitle('Online Travel Management System - Registration');
  }

  createUser() {
    this.submitted = true;
    if (this.registrationForm.invalid) {
      return;
    }

    this.user.userType = UserType[this.vehicle === null ? UserType.Customer : UserType.Employee];

    this.registrationService.createUser(this.user, this.vehicle).then((userId: string) => {
      if (userId) {
        this.router.navigate(['/login']);
      }
    }).catch((error: any) => {
      this.error = error.error;
    });
  }

  cancel() {
    this.router.navigate(['/login']);
  }
}
