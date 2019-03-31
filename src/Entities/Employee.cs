using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee : EntityBase
{
    public string Name { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
}