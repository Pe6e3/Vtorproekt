using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vtorproekt.Models
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; }

        [Display(Name = "Вид работы")]
        [ForeignKey(nameof(WorkTypeId))]
        public int WorkTypeId { get; set; }

        
        [Display(Name = "Дата ввода")]
        [DisplayFormat(DataFormatString = "yyyy-MM-ddTHH:mm", ApplyFormatInEditMode = true)]
        public DateTime DateTax { get; set; }


        [Display(Name = "Ставка (коп)")]
        public double TaxValue { get; set; }

        [Display(Name = "Норма I")]
        public double Limit1 { get; set; }

        [Display(Name = "Норма II")]
        public double Limit2 { get; set; }

        [Display(Name = "Норма III")]
        public double Limit3 { get; set; }

        [Display(Name = "Бонус I")]
        public double Multi1 { get; set; }

        [Display(Name = "Бонус II")]
        public double Multi2 { get; set; }

        [Display(Name = "Бонус III")]
        public double Multi3 { get; set; }

        public virtual ICollection<Production>? Productions { get; set; }
        public virtual WorkType? WorkType { get; set; }
        public virtual Material? Material { get; set; }
        
    }
}
