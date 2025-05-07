import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Doctor } from '@core/models/doctor.model';
import { DoctorDTO } from '@core/models/doctor-dto.model';
import { GLOBAL } from '@core/config/app.config';
import { EndpointType } from '@core/enums/endpoint-type.enum';

@Injectable({
  providedIn: 'root',
})
export class DoctorService {
  private apiUrl: string = '';

  constructor(private http: HttpClient) {
    this.apiUrl = `${GLOBAL.apiBaseUrl}/${EndpointType.Doctors}`;
  }

  getAll(): Observable<DoctorDTO[]> {
    const url = `${this.apiUrl}/dto`;
    return this.http.get<DoctorDTO[]>(url);
  }

  getById(id: number): Observable<DoctorDTO> {
    const url = `${this.apiUrl}/dto/${id}`;
    return this.http.get<DoctorDTO>(url);
  }

  add(doctor: Doctor): Observable<Doctor> {
    const url = `${this.apiUrl}`;
    return this.http.post<Doctor>(url, doctor);
  }

  update(doctor: Doctor): Observable<Doctor> {
    const url = `${this.apiUrl}/${doctor.id}`;
    return this.http.put<Doctor>(url, doctor);
  }

  delete(id: number): Observable<Doctor> {
    const url = `${this.apiUrl}/${id}`;

    return this.http.delete<Doctor>(url);
  }
}
