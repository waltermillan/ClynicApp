using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SpecialityRepository(Context context) : GenericRepository<Speciality>(context), ISpecialityRepository
{
    public async Task<Speciality> GetByCustomerIdAsync(int specialityId)
    {
        return await _context.Specialities
                             .FirstOrDefaultAsync(a => a.Id == specialityId);
    }

    public override async Task<Speciality> GetByIdAsync(int id)
    {
        return await _context.Specialities  
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Speciality>> GetAllAsync()
    {
        return await _context.Specialities.ToListAsync();
    }
}
