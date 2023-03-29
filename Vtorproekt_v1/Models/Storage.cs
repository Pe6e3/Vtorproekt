using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Storage
{
    [Key] public int StorageId { get; set; }
    public string StorageArdess { get; set; } = string.Empty;
}
