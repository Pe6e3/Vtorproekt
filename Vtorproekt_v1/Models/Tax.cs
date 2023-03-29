using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Tax
{
    [Key] public int TaxId { get; set; }
    public DateTime DateTax { get; set; }
    public int limit1 { get; set; }
    public int limit2 { get; set; }
    public int limit3 { get; set; }
    public int tax1 { get; set; }
    public int tax2 { get; set; }
    public int tax3 { get; set; }


}
