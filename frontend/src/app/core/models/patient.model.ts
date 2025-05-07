export class Patient {
  id: number;
  name: string;
  dateOfBirth: string;
  securityNumber: number;
  gender: string;

  constructor() {
    this.id = 0;
    this.name = '';
    this.dateOfBirth = '';
    this.securityNumber = 0;
    this.gender = '';
  }
}
