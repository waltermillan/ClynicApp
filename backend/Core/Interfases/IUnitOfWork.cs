using Core.Interfases;

namespace Core.Interfases;

public interface IUnitOfWork
{
	IPatientRepository Patients { get; }
    IAppointmentRepository Appointments { get; }
    IDoctorRepository Doctors { get; }
    IStaffRepository Staff { get; }
    ISpecialityRepository Specialities { get; }

    void Dispose();
    Task<int> SaveAsync();
}
