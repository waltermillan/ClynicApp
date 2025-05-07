using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Specialities")]
public class Speciality : BaseEntity
{
    [Column("Name")]
    public string Name { get; set; }
}
