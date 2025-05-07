export class DoctorDTO {
  id: number;
  name: string;
  idSpeciality: number;
  speciality: string;
  dateOfBirth: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.idSpeciality = 0;
    this.speciality = '';
    this.dateOfBirth = '';
  }
}
