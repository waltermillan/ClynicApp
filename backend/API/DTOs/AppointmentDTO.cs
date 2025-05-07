namespace API.DTOs;

public class AppointmentDTO
{
    public int Id { get; set; }                 //Table: Turns Field: Id
    public DateTime Date { get; set; }          //Table: Turns Field: Date
    public int IdPatient { get; set; }          //Table: Turns Field: IdPatient
    public string Patient { get; set; }         //Table: Patients Field: Name
    public int IdDoctor { get; set; }           //Table: Turns Field: IdDoctor
    public string Doctor { get; set; }          //Table: Doctors Field: Name
    public int IdStaff { get; set; }            //Table: Turns Field: IdStaff
    public string Staff { get; set; }           //Table: Staff Field: Name
}
