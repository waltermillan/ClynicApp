using Core.Interfases;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Context _context;

    private IPatientRepository _patients;
    private IAppointmentRepository _appointments;
    private IDoctorRepository _doctors;
    private IStaffRepository _staff;
    private ISpecialityRepository _specialities;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

	public IPatientRepository Patients
	{
		get
		{
			if (_patients is null)
				_patients = new PatientRepository(_context);

			return _patients;
		}
	}

	public IAppointmentRepository Appointments
    {
        get
        {
            if (_appointments is null)
                _appointments = new AppointmentRepository(_context);

            return _appointments;
        }
    }

    public IDoctorRepository Doctors
    {
        get
        {
            if (_doctors is null)
                _doctors = new DoctorRepository(_context);

            return _doctors;
        }
    }

    public IStaffRepository Staff
    {
        get
        {
            if (_staff is null)
                _staff = new StaffRepository(_context);

            return _staff;
        }
    }



    public ISpecialityRepository Specialities
    {
        get
        {
            if (_specialities is null)
                _specialities = new SpecialityRepository(_context);

            return _specialities;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
