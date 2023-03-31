using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Material
{
    [Key] public int MaterialId { get; set; }
    [Display (Name ="Вид сырья")]
    public string MaterialName { get; set; } = string.Empty;
}
