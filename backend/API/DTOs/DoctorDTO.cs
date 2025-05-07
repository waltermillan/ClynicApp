namespace API.DTOs;

public class DoctorDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdSpeciality { get; set; }
    public string Speciality { get; set; }
    public DateTime DateOfBirth { get; set; }
}
