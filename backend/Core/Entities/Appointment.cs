using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Appointments")]
public class Appointment : BaseEntity
{
    [Column("date")]
    public DateTime Date { get; set; }
    [Column("id_patient")]
    public int IdPatient { get; set; }
    [Column("id_doctor")]
    public int IdDoctor { get; set; }
    [Column("id_staff")]
    public int IdStaff { get; set; }
}
