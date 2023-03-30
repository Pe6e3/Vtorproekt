using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Tax
{
    [Key] public int TaxId { get; set; }
    public DateTime DateTax { get; set; }
    public int TaxValue { get; set; }
    public int Limit1 { get; set; }
    public int Limit2 { get; set; }
    public int Limit3 { get; set; }
    public int Multi1 { get; set; }
    public int Multi2 { get; set; }
    public int Multi3 { get; set; }


}
