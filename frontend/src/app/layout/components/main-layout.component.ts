import { Component } from '@angular/core';
import { AuthService } from '@core/services/auth.service';

@Component({
  selector: 'app-main-layout',
  standalone: false,
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent {
  userName: string = '';

  constructor(private authService: AuthService) {
    this.userName = 'NAME' 
  }
}
