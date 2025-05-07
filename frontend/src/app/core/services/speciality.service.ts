import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Speciality } from '@core/models/speciality.model';
import { GLOBAL } from '@core/config/app.config';
import { EndpointType } from '@core/enums/endpoint-type.enum';

@Injectable({
  providedIn: 'root',
})
export class SpecialityService {
  private apiUrl: string = '';

  constructor(private http: HttpClient) {
    this.apiUrl = `${GLOBAL.apiBaseUrl}/${EndpointType.Specialities}`;
  }

  getAll(): Observable<Speciality[]> {
    const url = `${this.apiUrl}`;

    return this.http.get<Speciality[]>(url);
  }

  getById(id: number): Observable<Speciality> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<Speciality>(url);
  }

  add(speciality: Speciality): Observable<Speciality> {
    const url = `${this.apiUrl}`;
    return this.http.post<Speciality>(url, speciality);
  }

  update(speciality: Speciality): Observable<Speciality> {
    const url = `${this.apiUrl}/${speciality.id}`;
    return this.http.put<Speciality>(url, speciality);
  }

  delete(id: number): Observable<Speciality> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<Speciality>(url);
  }
}
