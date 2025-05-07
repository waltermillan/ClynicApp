using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository(Context context) : GenericRepository<Patient>(context), IPatientRepository
{
    public async Task<Patient> GetByCustomerIdAsync(int patientId)
    {
        return await _context.Patients
                             .FirstOrDefaultAsync(a => a.Id == patientId);
    }

    public override async Task<Patient> GetByIdAsync(int id)
    {
        return await _context.Patients
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _context.Patients.ToListAsync();
    }
}
