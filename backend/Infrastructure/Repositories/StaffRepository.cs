using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class StaffRepository(Context context) : GenericRepository<Staff>(context), IStaffRepository
{
    public async Task<Staff> GetByCustomerIdAsync(int personalId)
    {
        return await _context.Staff
                             .FirstOrDefaultAsync(a => a.Id == personalId);
    }

    public override async Task<Staff> GetByIdAsync(int id)
    {
        return await _context.Staff
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Staff>> GetAllAsync()
    {
        return await _context.Staff.ToListAsync();
    }

    public async Task<Staff> GetByNameAsync(string userName)
    {
        return await _context.Staff
                          .FirstOrDefaultAsync(p => p.UserName == userName);    
    }
}
