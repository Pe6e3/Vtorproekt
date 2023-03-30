using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Employee
{
    [Key] public int EmployeeId { get; set; }

    [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
    [Display(Name = "Имя и Фамилия")]
    public string EmployeeName { get; set; } =string.Empty;
}
