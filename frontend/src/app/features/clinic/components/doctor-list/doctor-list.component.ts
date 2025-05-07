import { Component, OnInit } from '@angular/core';
import { Doctor } from '@core/models/doctor.model';
import { DoctorDTO } from '@core/models/doctor-dto.model';
import { DoctorService } from '@core/services/doctor.service';
import { Speciality } from '@core/models/speciality.model';
import { SpecialityService } from '@core/services/speciality.service';
import { DialogService } from '@core/services/dialog-service.service';
import { DialogType } from '@core/enums/dialog-type.enum';

@Component({
  selector: 'app-doctor-list',
  standalone: false,
  templateUrl: './doctor-list.component.html',
  styleUrl: './doctor-list.component.css'
})
export class DoctorListComponent implements OnInit {
  doctorList: DoctorDTO[] = []
  doctorNew: Doctor = new Doctor();
  specialities:Speciality[] = []

  constructor(private doctorService: DoctorService,
              private dialog: DialogService,
              private specialityService:SpecialityService) {
    
  }

  ngOnInit(){
    this.getAllDoctors();
    this.getAllSpecialities();
  }

  restore(): void {
    this.doctorNew = new Doctor();
  }

  getAllDoctors(){
    this.doctorService.getAll().subscribe({
      next: (data) => {
        this.doctorList = data;
      },
      error: (error) => {
        this.dialog.open('Error loading doctors.', DialogType.Failure);
      }
    });
  }

  getAllSpecialities(){
    this.specialityService.getAll().subscribe({
      next: (data) => {
        this.specialities = data;
      },
      error: (error) => {
        this.dialog.open('Error loading specialities.', DialogType.Failure);
      }
    });
  }

  addDoctor(){
    this.doctorService.add(this.doctorNew).subscribe({
      next: (data) => {
        this.getAllDoctors();
        this.restore();
        this.dialog.open('Doctor added successfully.', DialogType.Success);        
      },
      error: (error) => {
        this.dialog.open('Error adding new doctor.', DialogType.Failure);
      }
    });
  }

  deleteDoctor(id: number){
    this.doctorService.delete(id).subscribe({
      next: (data) => {
        this.dialog.open('Doctor deleted successfully.', DialogType.Success);

        this.getAllDoctors();
      },
      error: (error) => {
        this.dialog.open('Error deleting doctor.', DialogType.Failure);
      }
    });
  }

}
