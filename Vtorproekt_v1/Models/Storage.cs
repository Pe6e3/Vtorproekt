using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Storage
{
    [Display (Name ="Склад")]
    [Key] public int StorageId { get; set; }

    [StringLength(40, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 40 символов")]
    public string StorageAdress { get; set; } = string.Empty;
}
