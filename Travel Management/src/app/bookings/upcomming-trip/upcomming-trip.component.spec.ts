import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpcommingTripComponent } from './upcomming-trip.component';

describe('UpcommingTripComponent', () => {
  let component: UpcommingTripComponent;
  let fixture: ComponentFixture<UpcommingTripComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpcommingTripComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpcommingTripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
