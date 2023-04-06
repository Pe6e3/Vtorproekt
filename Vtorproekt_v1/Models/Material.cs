using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Material
{
    [Key] public int MaterialId { get; set; }


    [Display(Name = "Из чего делаем")]
    public string MaterialNameStart { get; set; } = string.Empty;

    [Display(Name = "Что получаем")]
    public string MaterialNameFinish { get; set; } = string.Empty;


}
