using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models;

public class Tax
{
    [Key] public int TaxId { get; set; }

    [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
    public DateTime DateTax { get; set; }

    public double TaxValue { get; set; }


    public double Limit1 { get; set; }
    public double Limit2 { get; set; }
    public double Limit3 { get; set; }
    public double Multi1 { get; set; }
    public double Multi2 { get; set; }
    public double Multi3 { get; set; }


}
