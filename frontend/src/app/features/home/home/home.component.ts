import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  standalone: false,
})
export class HomeComponent {
  sections = [
    { 
      title: 'Doctors', 
      content: `This section allows you to manage doctors. You can add new doctors to the system, update their details like contact information, specialty, and availability, view detailed doctor profiles, and remove doctors from the system if they are no longer needed. You can also filter doctors by specialty, location, or availability, making it easier to find the right doctor for a patient’s needs. All these operations are done through a secure, user-friendly interface to ensure smooth management of doctor data.`,
      isOpen: false 
    },
    { 
      title: 'Patients', 
      content: `In this section, you can register new patients, update their medical information, view their appointment history, and delete patient records. You can input essential details such as contact information, medical history, and emergency contacts. Each patient record is linked to their appointments, which you can easily manage and track. The system also allows you to view detailed patient profiles, including their medical tests and treatment history, ensuring that all patient data is stored and maintained efficiently.`,
      isOpen: false 
    },
    { 
      title: 'Staff', 
      content: `This section is for managing your administrative staff. You can add new staff members, assign them specific roles (e.g., receptionist, nurse, administrator), modify their personal and professional details, and remove staff members when they leave the organization. You can also manage access permissions for different roles, ensuring that each staff member only has access to the parts of the system they need. This feature ensures a smooth workflow for your organization by keeping track of who is responsible for what tasks.`,
      isOpen: false 
    },
    { 
      title: 'Appointments', 
      content: `In this section, you can schedule new medical appointments for patients, view all upcoming appointments, modify appointment times based on doctor availability, and cancel appointments when necessary. The system helps manage doctor-patient scheduling efficiently by providing a calendar interface, ensuring that no conflicts arise. You can also set reminders and send automated notifications to both patients and doctors about upcoming appointments, helping reduce no-shows and improve overall organization.`,
      isOpen: false 
    },
    { 
      title: 'Specialities', 
      content: `In this section, you can add new specialties as the medical staff grows. You can also delete specialties when doctors are no longer available.`,
      isOpen: false 
    }
  ];
}
