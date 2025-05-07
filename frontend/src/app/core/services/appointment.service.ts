import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Appointment } from '@core/models/appointment.model';
import { AppointmentDTO } from '@core/models/appointment-dto.model';
import { GLOBAL } from '@core/config/app.config';
import { EndpointType } from '@core/enums/endpoint-type.enum';

@Injectable({
  providedIn: 'root',
})
export class AppointmentService {
  private apiUrl: string = '';

  constructor(private http: HttpClient) {
    this.apiUrl = `${GLOBAL.apiBaseUrl}/${EndpointType.Appointments}`;
  }

  getAll(): Observable<AppointmentDTO[]> {
    const url = `${this.apiUrl}/dto`;
    return this.http.get<AppointmentDTO[]>(url);
  }

  getById(id: number): Observable<AppointmentDTO> {
    const url = `${this.apiUrl}/dto/${id}`;
    return this.http.get<AppointmentDTO>(url);
  }

  add(appointment: Appointment): Observable<Appointment> {
    const url = `${this.apiUrl}`;

    return this.http.post<Appointment>(url, appointment);
  }

  update(appointment: Appointment): Observable<Appointment> {
    const url = `${this.apiUrl}/${appointment.id}`;
    return this.http.put<Appointment>(url, appointment);
  }

  delete(id: number): Observable<Appointment> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<Appointment>(url);
  }
}
