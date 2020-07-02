import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { TripSummaryComponent } from './trip-summary.component';
import { BookingComponent } from './booking.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UpcommingTripComponent } from './upcomming-trip/upcomming-trip.component';
import { BookingDetailsComponent } from './booking-details/booking-details.component';

const routers: Routes = [
  { path: '', component: TripSummaryComponent },
  { path: 'create', component: BookingComponent },
  { path: 'booking-detail', component: BookingDetailsComponent }
];

@NgModule({
  declarations: [
    TripSummaryComponent,
    BookingComponent,
    UpcommingTripComponent,
    BookingDetailsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forChild(routers)
  ],
  providers: [
    DatePipe
  ]
})
export class BookingModule { }
