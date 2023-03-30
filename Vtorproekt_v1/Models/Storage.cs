using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Storage
{
    [Key] public int StorageId { get; set; }

    [StringLength(40, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 40 символов")]
    public string StorageArdess { get; set; } = string.Empty;
}
