using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Material
{
    [Key] public int MaterialId { get; set; }
    public string MaterialName { get; set; } = string.Empty;
}
