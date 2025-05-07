import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from '@core/models/patient.model';
import { GLOBAL } from '@core/config/app.config';
import { EndpointType } from '@core/enums/endpoint-type.enum';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  private apiUrl: string = '';

  constructor(private http: HttpClient) {
    this.apiUrl = `${GLOBAL.apiBaseUrl}/${EndpointType.Patients}`;
  }

  getAll(): Observable<Patient[]> {
    const url = `${this.apiUrl}`;
    return this.http.get<Patient[]>(url);
  }

  getById(id: number): Observable<Patient> {
    const url = `${this.apiUrl}${id}`;
    return this.http.get<Patient>(url);
  }

  add(patient: Patient): Observable<Patient> {
    const url = `${this.apiUrl}`;

    return this.http.post<Patient>(url, patient);
  }

  update(patient: Patient): Observable<Patient> {
    const url = `${this.apiUrl}/${patient.id}`;
    return this.http.put<Patient>(url, patient);
  }

  delete(id: number): Observable<Patient> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<Patient>(url);
  }
}
