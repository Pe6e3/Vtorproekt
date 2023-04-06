using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Material
{
    [Key] public int MaterialId { get; set; }


    [Display(Name = "Название сырья")]
    public string MaterialNameStart { get; set; } = string.Empty;

    [Display(Name = "Название готового продукта")]
    public string MaterialNameFinish { get; set; } = string.Empty;


}
