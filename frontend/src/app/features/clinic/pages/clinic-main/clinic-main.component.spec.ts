import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClinicMainComponent } from './clinic-main.component';

describe('ClinicMainComponent', () => {
  let component: ClinicMainComponent;
  let fixture: ComponentFixture<ClinicMainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClinicMainComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClinicMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
