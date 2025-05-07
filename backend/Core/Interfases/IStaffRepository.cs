using Core.Entities;

namespace Core.Interfases;

public interface IStaffRepository : IGenericRepository<Staff>
{
    Task<Staff> GetByNameAsync(string name);
}
