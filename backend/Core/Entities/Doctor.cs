using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Doctors")]
public class Doctor : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }
    [Column("id_speciality")]
    public int IdSpeciality { get; set; }
    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }
}
