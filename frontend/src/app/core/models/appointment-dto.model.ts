export class AppointmentDTO {
  id: number;
  date: string;
  idPatient: number;
  patient: string;
  idDoctor: number;
  doctor: string;
  idPersonal: number;
  staff: string;


  constructor() {
    this.id = 0;
    this.date = '';
    this.idPatient = 0;
    this.patient = '';
    this.idDoctor = 0;
    this.doctor = '';
    this.idPersonal = 0;
    this.staff = '';
  }
}
