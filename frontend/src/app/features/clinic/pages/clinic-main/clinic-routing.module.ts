import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicMainComponent } from './clinic-main.component';
import { DoctorListComponent } from '@features/clinic/components/doctor-list/doctor-list.component';
import { StaffListComponent } from '@features/clinic/components/staff-list/staff-list.component';
import { PatientListComponent } from '@features/clinic/components/patient-list/patient-list.component';
import { SpecialityListComponent } from '@features/clinic/components/speciality-list/speciality-list.component';
import { AppointmentListComponent } from '@features/clinic/components/appointment-list/appointment-list.component';

const routes: Routes = [
  {
    path: '',
    component: ClinicMainComponent,
    children: [
      { path: 'doctors', component: DoctorListComponent },
      { path: 'staff', component: StaffListComponent },
      { path: 'patients', component: PatientListComponent },
      { path: 'specialities', component: SpecialityListComponent },
      { path: 'appointments', component: AppointmentListComponent },
      { path: '', redirectTo: 'doctors', pathMatch: 'full' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClinicRoutingModule { }
