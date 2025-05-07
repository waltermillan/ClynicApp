import { Component, OnInit } from '@angular/core';
import { Patient } from '@core/models/patient.model';
import { PatientService } from '@core/services/patient.service';
import { DialogService } from '@core/services/dialog-service.service';
import { DialogType } from '@core/enums/dialog-type.enum';

@Component({
  selector: 'app-patient-list',
  standalone: false,
  templateUrl: './patient-list.component.html',
  styleUrl: './patient-list.component.css'
})
export class PatientListComponent implements OnInit {
  patientList: Patient[] = []
  patientNew:Patient = new Patient();

  constructor(private patientService: PatientService,
              private dialog: DialogService) {
    
  }

  ngOnInit(): void {
    this.getAllPatients();
  }

  restore(): void {
    this.patientNew = new Patient();
  }

  getAllPatients(){
    this.patientService.getAll().subscribe({
      next: (data) => {
        this.patientList = data;
      },
      error: (error) => {
        this.dialog.open('Error getting patients.', DialogType.Failure);
      }
    });
  }

  addPatient(){
    this.patientService.add(this.patientNew).subscribe({
      next: (data) => {
        this.getAllPatients();
        this.restore();
        this.dialog.open('Patient added successfully.', DialogType.Success);
      },
      error: (error) => {
        this.dialog.open('Error adding patients.', DialogType.Failure);
      }
    });
  }

  deletePatient(id: number){
    this.patientService.delete(id).subscribe({
      next: (data) => {
        this.getAllPatients();
        this.dialog.open('Patient deleted successfully.', DialogType.Success);
      },
      error: (error) => {
        this.dialog.open('Error deleting patients.', DialogType.Failure);
      }
    });
  }
}
