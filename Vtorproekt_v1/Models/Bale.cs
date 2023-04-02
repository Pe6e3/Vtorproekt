using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vtorproekt.Models
{
    public class Bale
    {
        [Display (Name="Номер тюка")]
        [DisplayFormat(DataFormatString = "{0:0000}")]
        [Key] public int BaleId { get; set; }


        [Display (Name="Кто готовит тюк")]
        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }



        [Display(Name = "Вид сырья")]
        [ForeignKey("MaterialId")]
        public int? MaterialId { get; set; }
        public virtual Material? Material { get; set; }


        [Display(Name = "Готов")]
        public bool isReady { get; set; } = false;

    }
}
