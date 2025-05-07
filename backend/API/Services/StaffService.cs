using API.DTOs;
using Core.Entities;
using Core.Interfases;

namespace API.Services;

public class StaffService
{
    IStaffRepository _staffRepository;

    public StaffService(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    public async Task<IEnumerable<StaffDTO>> GetAllStaffDTOsAsync()
    {
        var staff = await _staffRepository.GetAllAsync();

        List<StaffDTO> staffDTOs = new List<StaffDTO>();   

        foreach (var item in staff)
        {

            var staffDTO = new StaffDTO
            {
                Id = item.Id,
                Name = item.Name,
                UserName = item.UserName,
                DateofBirth = item.DateofBirth
            };

            staffDTOs.Add(staffDTO);
        }

        return staffDTOs;
    }

    public async Task<StaffDTO> GetByIdStaffDTOAsync(int id)
    {
        var staff = await _staffRepository.GetByIdAsync(id);

        var staffDTO = new StaffDTO
        {
            Id = staff.Id,
            Name = staff.Name,
            UserName = staff.UserName,
            DateofBirth = staff.DateofBirth
        };

        return staffDTO;
    }

    public async Task<Staff> GetByNameAsync(string name)
    {
        return await _staffRepository.GetByNameAsync(name);
    }
}
