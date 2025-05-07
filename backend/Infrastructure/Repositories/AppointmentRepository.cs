using Core.Entities;
using Core.Interfases;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AppointmentRepository(Context context) : GenericRepository<Appointment>(context), IAppointmentRepository
{
    public async Task<Appointment> GetByCustomerIdAsync(int turnId)
    {
        return await _context.Appointments
                             .FirstOrDefaultAsync(a => a.Id == turnId);
    }

    public override async Task<Appointment> GetByIdAsync(int id)
    {
        return await _context.Appointments
                          .FirstOrDefaultAsync(p => p.Id == id);
    }

    public override async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _context.Appointments.ToListAsync();
    }
}
