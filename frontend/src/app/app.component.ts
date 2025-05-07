import { Component, OnInit } from '@angular/core';
import { AuthService } from '@core/services/auth.service';

@Component({
  standalone: false,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'Products';
  isLogged: boolean = false;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.restoreSession();  // the session must be restored
    this.authService.isLoggedIn$.subscribe((isLogged) => {
      this.isLogged = isLogged;
    });
  }
}
