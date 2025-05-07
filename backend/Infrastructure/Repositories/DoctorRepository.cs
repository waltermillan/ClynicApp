using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DoctorRepository(Context context) : GenericRepository<Doctor>(context), IDoctorRepository
{
    public async Task<Doctor> GetByCustomerIdAsync(int doctorId)
    {
        return await _context.Doctors
                             .FirstOrDefaultAsync(a => a.Id == doctorId);
    }

    public override async Task<Doctor> GetByIdAsync(int id)
    {
        return await _context.Doctors
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Doctor>> GetAllAsync()
    {
        return await _context.Doctors.ToListAsync();
    }
}
