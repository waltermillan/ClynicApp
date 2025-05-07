using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

[Table("Staff")]
public class Staff : BaseEntity
{
    [Column("name")]
    public string Name { get; set; }

    [Column("user_name")]
    public string UserName { get; set; }

    [Column("date_of_birth")]
    public DateTime DateofBirth { get; set; }
    [Column("password")]
    public string Password { get; set; }
}
