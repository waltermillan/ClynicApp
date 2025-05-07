import { Component, OnInit } from '@angular/core';
import { AuthService } from '@core/services/auth.service';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  name: string = ''
  userName: string = '';

  constructor(private authService: AuthService) {

  }

  ngOnInit(): void {
    // Subscribe to the userData$ observable to get the user's data
    this.authService.userData$.subscribe((userData) => {
      if (userData) {
        this.userName = userData.userName;
        this.name = userData.name;
      }
    });
  }

  logout(){
    this.authService.logout();
  }
}


