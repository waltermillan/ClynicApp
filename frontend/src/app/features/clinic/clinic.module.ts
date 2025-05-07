import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ClinicRoutingModule } from './clinic-routing.module';

import { DoctorListComponent } from './components/doctor-list/doctor-list.component';
import { StaffListComponent } from './components/staff-list/staff-list.component';
import { PatientListComponent } from './components/patient-list//patient-list.component';
import { SpecialityListComponent } from './components/speciality-list/speciality-list.component';
import { AppointmentListComponent } from './components/appointment-list/appointment-list.component';
import { ClinicMainComponent } from './pages/clinic-main/clinic-main.component';

@NgModule({
  declarations: [
    DoctorListComponent,
    StaffListComponent,
    PatientListComponent,
    SpecialityListComponent,
    AppointmentListComponent,
    ClinicMainComponent
  ],
  imports: [
    CommonModule,
    ClinicRoutingModule,
    FormsModule
  ]
})
export class ClinicModule { }
