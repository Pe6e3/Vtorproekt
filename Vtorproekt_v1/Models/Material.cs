using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Material
{
    [Key] public int MaterialId { get; set; }


    [Display(Name = "Названия сырья")]
    public string MaterialNameStart { get; set; } = string.Empty;

    [Display(Name = "Названия готового продукта")]
    public string MaterialNameFinish { get; set; } = string.Empty;


}
