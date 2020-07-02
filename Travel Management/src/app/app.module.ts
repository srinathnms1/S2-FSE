import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthInterceptor } from './services/auth-interceptor.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { SpinnerComponent } from './core/spinner/spinner.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { HeaderComponent } from './core/header/header.component';
import { FooterComponent } from './core/footer/footer.component';
import { MatSliderModule } from '@angular/material/slider';
import AuthRestRequester from './services/auth-http-handler';
import BookingRestRequester from './services/booking-http-handler';
import VehicleRestRequester from './services/vehicle-http-handler';

@NgModule({
  declarations: [
    AppComponent,
    SpinnerComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NgbModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    MatSliderModule,
    NgMultiSelectDropDownModule.forRoot()
  ],
  providers: [
    NgbActiveModal,
    AuthRestRequester,
    BookingRestRequester,
    VehicleRestRequester,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    AuthInterceptor,
    Title
  ],
  bootstrap: [AppComponent],
  entryComponents: [
  ]
})
export class AppModule { }
