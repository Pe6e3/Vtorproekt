using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Employee
{
    [Key] public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } =string.Empty;
}
