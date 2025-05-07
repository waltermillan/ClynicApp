namespace API.DTOs;

public class StaffDTO
{
    public int Id { get; set; }                         //Table: Personal | Field: Id
    public string Name { get; set; }                    //Table: Personal | Field: Name
    public string UserName { get; set; }                //Table: Personal | Field: UserName
    public DateTime DateofBirth { get; set; }           //Table: Personal | Field: DateofBirth
}
