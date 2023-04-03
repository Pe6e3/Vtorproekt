using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vtorproekt.Models
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; }

        [Display(Name = "На какой вид работ данный тариф")]
        [ForeignKey(nameof(WorkType.WorkTypeId))]
        public int WorkTypeId { get; set; }

        [Display(Name = "Дата ввода тарифа")]
        [DisplayFormat(DataFormatString = "yyyy-MM-ddTHH:mm", ApplyFormatInEditMode = true)]
        public DateTime DateTax { get; set; }


        [Display(Name = "Ставка тарифа (коп)")]
        public double TaxValue { get; set; }

        [Display(Name = "Первый норматив")]
        public double Limit1 { get; set; }

        [Display(Name = "Второй норматив")]
        public double Limit2 { get; set; }

        [Display(Name = "Третий норматив")]
        public double Limit3 { get; set; }

        [Display(Name = "Первая надбавка %")]
        public double Multi1 { get; set; }

        [Display(Name = "Вторая надбавка %")]
        public double Multi2 { get; set; }

        [Display(Name = "Третья надбавка %")]
        public double Multi3 { get; set; }

        public virtual ICollection<Production>? Productions { get; set; }
        
    }
}
