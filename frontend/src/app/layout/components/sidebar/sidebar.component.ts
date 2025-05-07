import { Component } from '@angular/core';
import { GLOBAL } from '../../../core/config/app.config';

@Component({
  selector: 'app-sidebar',
  standalone: false,
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent {

  appVersion: string = '';
  buildingDate: string = ''
  notes: string = ''
  showVersionDetails: boolean = false;

  constructor() {
    this.appVersion = GLOBAL.appVersion;
    this.buildingDate = GLOBAL.buildingDate;
    this.notes = GLOBAL.notes;
    this.showVersionDetails = false;
    
  }
}
