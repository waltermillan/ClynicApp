import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClinicMainComponent } from './pages/clinic-main/clinic-main.component';
import { DoctorListComponent } from './components/doctor-list/doctor-list.component';
import { StaffListComponent } from './components/staff-list/staff-list.component';
import { PatientListComponent } from './components/patient-list/patient-list.component';
import { SpecialityListComponent } from './components/speciality-list/speciality-list.component';
import { AppointmentListComponent } from './components/appointment-list/appointment-list.component';

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
