import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BookingService } from './booking.service';
import { BookingViewModel } from 'src/api-client/booking/api-types';
import { DatePipe } from '@angular/common';
import { NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-booking',
    templateUrl: './booking.component.html'
})
export class BookingComponent implements OnInit {

    message: string;
    submitted = false;
    bookingForm: FormGroup;
    @Input() bookingViewModel: BookingViewModel;

    // tslint:disable-next-line: max-line-length
    constructor(private formBuilder: FormBuilder, private bookingService: BookingService, private router: Router, private authService: AuthService
    ) {
     }

    ngOnInit(): void {
        const { name, mobile } = this.authService.currentUserValue;
        const dateTime = new Date();
        const ngbDate: NgbDate = new NgbDate(dateTime.getFullYear(), dateTime.getMonth(), dateTime.getDate());
        this.bookingForm = this.formBuilder.group({
            from: [null, Validators.required],
            to: [null, Validators.required],
            numberOfPassanger: [1, Validators.required],
            customerName: [name, Validators.required],
            customerMobile: [mobile, Validators.required],
            date: [ngbDate, Validators.required],
            time: [{ hour: dateTime.getHours(), minute: dateTime.getMinutes() }, Validators.required]
        });
        this.bookingForm.valueChanges.subscribe(booking => {
            this.bookingViewModel = booking;
        });
    }

    save(): void {
        this.submitted = true;
        if (this.bookingForm.invalid) {
            return;
        }

        const date = this.bookingForm.get('date');
        const time = this.bookingForm.get('time');
        const selectedDate = new Date(date.value.year, date.value.month, date.value.day, time.value.hour, time.value.minute);
        this.bookingViewModel.date = selectedDate.toLocaleString();
        this.bookingViewModel.customerId = this.authService.currentUserValue.id;
        this.bookingService.save(this.bookingViewModel).then((isSuccess: boolean) => {
            if (isSuccess) {
                this.router.navigate(['/booking']);
            }
        }).catch((error: any) => { this.message = error.error; });
    }
}
