using API.DTOs;
using Core.Entities;
using Core.Interfases;

namespace API.Services;

public class DoctorService
{
    IDoctorRepository _doctorRepository;
    ISpecialityRepository _specialityRepository;

    public DoctorService(IDoctorRepository doctorRepository, ISpecialityRepository specialityRepository)
    {
        _doctorRepository = doctorRepository;
        _specialityRepository = specialityRepository;
    }

    public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsDTOsAsync()
    {
        var doctors = await _doctorRepository.GetAllAsync();

        List<DoctorDTO> doctorsDTOs = new List<DoctorDTO>();   

        foreach (var item in doctors)
        {
            var speciality = await _specialityRepository.GetByIdAsync(item.IdSpeciality);
            var doctorDTO = new DoctorDTO
            {
                Id = item.Id,
                Name = item.Name,
                IdSpeciality = item.IdSpeciality,
                Speciality = speciality.Name,
                DateOfBirth = item.DateOfBirth
            };

            doctorsDTOs.Add(doctorDTO);
        }

        return doctorsDTOs;
    }

    public async Task<DoctorDTO> GetByIdDoctorDTOAsync(int id)
    {
        var doctor = await _doctorRepository.GetByIdAsync(id);
        var speciality = await _specialityRepository.GetByIdAsync(doctor.Id);

        var doctorDTO = new DoctorDTO
        {
            Id = doctor.Id,
            Name = doctor.Name,
            IdSpeciality = doctor.IdSpeciality,
            Speciality = speciality.Name,
            DateOfBirth = doctor.DateOfBirth
        };

        return doctorDTO;
    }
}
