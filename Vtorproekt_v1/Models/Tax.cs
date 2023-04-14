using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtorP.Models
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; }

        [Display(Name = "Вид работы")]
        [ForeignKey(nameof(WorkTypeId))]
        public int WorkTypeId { get; set; }


        [Display(Name = "Что получаем")]
        [ForeignKey(nameof(MaterialId))]
        public int MaterialId { get; set; }



        [Display(Name = "Дата ввода")]
        [DisplayFormat(DataFormatString = "yyyy-MM-ddTHH:mm", ApplyFormatInEditMode = true)]
        public DateTime DateTax { get; set; }


        [Display(Name = "Ставка")]
        public double TaxValue { get; set; }


        public virtual ICollection<Production>? Productions { get; set; }
        public virtual WorkType? WorkType { get; set; }
        public virtual Material? Material { get; set; }
        
    }
}
