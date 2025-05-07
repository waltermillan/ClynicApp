using API.DTOs;
using Core.Interfases;

namespace API.Services;

public class AppointmentService
{
    IAppointmentRepository _appointmentRepository;
    IPatientRepository _patientRepository;
    IDoctorRepository _doctorRepository;
    IStaffRepository _staffRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository, 
                        IPatientRepository patientRepository, 
                        IDoctorRepository doctorRepository, 
                        IStaffRepository staffRepository)
    {
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _appointmentRepository = appointmentRepository;
        _staffRepository = staffRepository;
    }

    public async Task<IEnumerable<AppointmentDTO>> GetAllAppointmentDTOsAsync()
    {
        var appointments = await _appointmentRepository.GetAllAsync();

        List<AppointmentDTO> appointmentList = new List<AppointmentDTO>();   

        foreach (var turn in appointments)
        {
            var patient = await _patientRepository.GetByIdAsync(turn.IdPatient);
            var doctor = await _doctorRepository.GetByIdAsync(turn.IdDoctor);
            var personal = await _staffRepository.GetByIdAsync(turn.IdStaff);

            var appointmentDTO = new AppointmentDTO
            {
                Id = turn.Id,
                Date = turn.Date,
                IdPatient = turn.IdPatient,
                Patient = patient.Name,
                IdDoctor = turn.IdDoctor,
                Doctor = doctor.Name,
                IdStaff = turn.IdStaff,
                Staff = personal.Name
            };

            appointmentList.Add(appointmentDTO);
        }

        return appointmentList;
    }

    public async Task<AppointmentDTO> GetByIdAppointmentDTOsAsync(int id)
    {
        var appointment = await _appointmentRepository.GetByIdAsync(id);
        var patient = await _patientRepository.GetByIdAsync(appointment.IdPatient);
        var doctor = await _doctorRepository.GetByIdAsync(appointment.IdDoctor);
        var staff = await _staffRepository.GetByIdAsync(appointment.IdStaff);

        var appointmentDTO = new AppointmentDTO
        {
            Id = appointment.Id,
            Date = appointment.Date,
            IdPatient = appointment.IdPatient,
            Patient = patient.Name,
            IdDoctor = appointment.IdDoctor,
            Doctor = doctor.Name,
            IdStaff = appointment.IdStaff,
            Staff = staff.Name
        };

        return appointmentDTO;
    }
}
