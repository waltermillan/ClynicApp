import { Component, OnInit } from '@angular/core';
import { AppointmentDTO } from '@core/models/appointment-dto.model';
import { Doctor } from '@core/models/doctor.model';
import { Patient } from '@core/models/patient.model';
import { StaffDTO } from '@core/models/staff-dto.model';
import { AppointmentService } from '@core/services/appointment.service';
import { DoctorService } from '@core/services/doctor.service';
import { PatientService } from '@core/services/patient.service';
import { StaffService } from '@core/services/staff.service';
import { Appointment } from '@core/models/appointment.model';
import { DialogService } from '@core/services/dialog-service.service';
import { DialogType } from '@core/enums/dialog-type.enum';

@Component({
  selector: 'app-appointment-list',
  standalone: false,
  templateUrl: './appointment-list.component.html',
  styleUrl: './appointment-list.component.css'
})
export class AppointmentListComponent implements OnInit {
  appointmentList: AppointmentDTO[] = [];
  patients:Patient [] = [];
  doctors: Doctor[] = []
  staff: StaffDTO[] = [];
  appointmentNew: Appointment = new Appointment();

  constructor(private appointmentService: AppointmentService,
              private doctorService: DoctorService,
              private patientService: PatientService,
              private dialog: DialogService,
              private staffService: StaffService) {
    
  }

  ngOnInit(): void {
    this.getAllAppointments();
    this.getAllDoctors();
    this.getAllPatients();
    this.getAllStaff();
  }

  restore(): void {
    this.appointmentNew = new Appointment();
  }

  getAllAppointments(){
    this.appointmentService.getAll().subscribe({
      next: (data) => {
        this.appointmentList = data;
      },
      error: (error) => {
        this.dialog.open('Error loading appointments.', DialogType.Failure);
      }
    });
  }

  getAllDoctors(){
    this.doctorService.getAll().subscribe({
      next: (data) => {
        this.doctors = data;
      },
      error: (error) => {
        this.dialog.open('Error loading doctors.', DialogType.Failure);
      }
    });
  }

  getAllPatients(){
    this.patientService.getAll().subscribe({
      next: (data) => {
        this.patients = data;
      },
      error: (error) => {
        this.dialog.open('Error loading patients.', DialogType.Failure);
      }
    });
  }

  getAllStaff(){
    this.staffService.getAll().subscribe({
      next: (data) => {
        this.staff = data;
      },
      error: (error) => {
        this.dialog.open('Error loading staff.', DialogType.Failure);
      }
    });
  }

  addAppointment(){
    this.appointmentService.add(this.appointmentNew).subscribe({
      next: (data) => {
        this.getAllAppointments()
        this.restore();
        this.dialog.open('Appointment added successfully.', DialogType.Success);        
      },
      error: (error) => {
        this.dialog.open('Error adding new appointment.', DialogType.Failure);
      }
    });
  }

  deleteAppointment(id:number){
    this.appointmentService.delete(id).subscribe({
      next: (data) => {
        this.dialog.open('Appointment deleted successfully.', DialogType.Success);
        this.getAllAppointments()
      },
      error: (error) => {
        this.dialog.open('Error deleting appointment.', DialogType.Failure);
      }
    });
  }

}
