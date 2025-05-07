import { Component, OnInit } from '@angular/core';
import { StaffDTO } from '@core/models/staff-dto.model';
import { Staff } from '@core/models/staff.model';
import { StaffService } from '@core/services/staff.service';
import { DialogService } from '@core/services/dialog-service.service';
import { DialogType } from '@core/enums/dialog-type.enum';
import { AuthService } from '@core/services/auth.service';

@Component({
  selector: 'app-staff-list',
  standalone: false,
  templateUrl: './staff-list.component.html',
})
export class StaffListComponent implements OnInit {
  staffList: StaffDTO[] = [];
  staffNew: Staff = new Staff();
  userLogged:string = '';

  constructor(private staffService: StaffService,
              private authService: AuthService,
              private dialog: DialogService) {

  }

  ngOnInit(): void {
    this.getAllStaff();

    this.authService.userData$.subscribe((userData) => {
      if (userData) {
        this.userLogged = userData.userName;
      }
    });

  }

  restore(): void {
    this.staffNew = new Staff();
  }

  getAllStaff(){
    this.staffService.getAll().subscribe({
      next: (data) => {
        this.staffList = data;
      },
      error: (error) => {
        this.dialog.open('Error getting staff.', DialogType.Failure);
      }
    });    
  }

  addStaff(){
    this.staffService.add(this.staffNew).subscribe({
      next: (data) => {
        this.getAllStaff();
        this.dialog.open('Staff added successfully.', DialogType.Success);
        this.restore();
      },
      error: (error) => {
        this.dialog.open('Error adding staff.', DialogType.Failure);
      }
    });   
  }

  deleteStaff(id: number){
    this.staffService.delete(id).subscribe({
      next: (data) => {
        this.getAllStaff();
        this.dialog.open('Staff deleted successfully.', DialogType.Success);
      },
      error: (error) => {
        this.dialog.open('Error deleting staff.', DialogType.Failure);
      }
    });   
  }

  showSpetialMessage(){
    this.dialog.open('You cannot delete your own data.', DialogType.Warning);
  }
}

