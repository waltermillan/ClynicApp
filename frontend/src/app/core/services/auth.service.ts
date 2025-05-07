import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { GLOBAL } from '@core/config/app.config';
import { EndpointType } from '@core/enums/endpoint-type.enum';
import { LoginRequest } from '@core/interfaces/login-request.interface';
import { UserData } from '@core/interfaces/user-data.interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl: string = '';
  private loggedIn = new BehaviorSubject<boolean>(false);
  private userData = new BehaviorSubject<UserData | null>(null);

  isLoggedIn$ = this.loggedIn.asObservable();
  userData$ = this.userData.asObservable();

  constructor(private http: HttpClient) {
    this.apiUrl = `${GLOBAL.apiBaseUrl}/${EndpointType.Staff}`;
    this.restoreSession();
  }

  restoreSession(): void {
    const token = localStorage.getItem('token');
    const storedUserData = localStorage.getItem('userData');

    if (token) {
      this.loggedIn.next(true);
      if (storedUserData) {
        this.userData.next(JSON.parse(storedUserData));
      }
    } else {
      this.loggedIn.next(false);
      this.userData.next(null);
    }
  }

  isLoggedIn(): boolean {
    return this.loggedIn.value;
  }

  login(userName: string, password: string): Observable<any> {
    const url = `${this.apiUrl}/login`;
    const body: LoginRequest = {
      username: userName,
      password: password,
    };

    return this.http.post<any>(url, body).pipe(
      tap((response) => {
        localStorage.setItem('token', response.token);
        localStorage.setItem('userData', JSON.stringify(response.data));
        this.userData.next(response.data);
        this.loggedIn.next(true);
      })
    );
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('userData');
    this.loggedIn.next(false);
    this.userData.next(null);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
