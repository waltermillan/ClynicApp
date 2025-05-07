import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Staff } from '@core/models/staff.model';
import { StaffDTO } from '@core/models/staff-dto.model';
import { GLOBAL } from '@core/config/app.config';
import { EndpointType } from '@core/enums/endpoint-type.enum';

@Injectable({
  providedIn: 'root',
})
export class StaffService {
  private apiUrl: string = '';

  constructor(private http: HttpClient) {
    this.apiUrl = `${GLOBAL.apiBaseUrl}/${EndpointType.Staff}`;
  }

  getAll(): Observable<StaffDTO[]> {
    const url = `${this.apiUrl}`;
    return this.http.get<StaffDTO[]>(url);
  }

  getById(id: number): Observable<StaffDTO> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.get<StaffDTO>(url);
  }

  add(staff: Staff): Observable<Staff> {
    const url = `${this.apiUrl}`;
    return this.http.post<Staff>(url, staff);
  }

  update(staff: Staff): Observable<Staff> {
    const url = `${this.apiUrl}/${staff.id}`;
    return this.http.put<Staff>(url, staff);
  }

  delete(id: number): Observable<Staff> {
    const url = `${this.apiUrl}/${id}`;
    return this.http.delete<Staff>(url);
  }
}
