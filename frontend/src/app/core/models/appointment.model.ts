export class Appointment {
  id: number;
  date: string;
  idPatient: number;
  idDoctor: number;
  idStaff: number;


  constructor() {
    this.id = 0;
    this.date = '';
    this.idPatient = 0;
    this.idDoctor = 0;
    this.idStaff = 0;
  }
}
