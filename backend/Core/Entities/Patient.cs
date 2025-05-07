using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Patients")]
public class Patient : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }

    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }

    [Column("security_number")]
    public int SecurityNumber { get; set; }

    [Column("gender")]
    public char Gender { get; set; }
}
