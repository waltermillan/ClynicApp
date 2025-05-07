import { Component, OnInit } from '@angular/core';
import { DialogType } from '@core/enums/dialog-type.enum';
import { Speciality } from '@core/models/speciality.model';
import { DialogService } from '@core/services/dialog-service.service';
import { SpecialityService } from '@core/services/speciality.service';

@Component({
  selector: 'app-speciality-list',
  standalone: false,
  templateUrl: './speciality-list.component.html',
  styleUrl: './speciality-list.component.css'
})
export class SpecialityListComponent implements OnInit {

  specialityList: Speciality[] = [];
  specialityNew: Speciality = new Speciality();

  constructor(private specialityService: SpecialityService,
              private dialog: DialogService) {
    
  }

  ngOnInit(): void {
    this.getAllSpecialities();
  }

  restore(): void {
    this.specialityNew = new Speciality();
  }

  getAllSpecialities(){
      this.specialityService.getAll().subscribe({
        next: (data) => {
          this.specialityList = data;
        },
        error: (error) => {
          this.dialog.open('Error getting specialities.', DialogType.Failure);
        }
      });
  }

  addSpeciality(){
    this.specialityService.add(this.specialityNew).subscribe({
      next: (data) => {
        this.getAllSpecialities();
        this.restore();
        this.dialog.open('Speciality addedd successfully.', DialogType.Success);

      },
      error: (error) => {
        this.dialog.open('Error adding speciality.', DialogType.Failure);
      }
    });
  }

  deleteSpeciality(id: number){
    this.specialityService.delete(id).subscribe({
      next: (data) => {
        this.getAllSpecialities()
        this.dialog.open('Speciality deleted successfully.', DialogType.Success);
      },
      error: (error) => {
        this.dialog.open('Error deleting speciality.', DialogType.Failure);
      }
    });
  }
}
