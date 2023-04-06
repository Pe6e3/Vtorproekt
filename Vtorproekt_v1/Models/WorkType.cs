using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vtorproekt.Models
{
    public class WorkType
    {
        [Display (Name ="Вид работы")]
        [Key] public int WorkTypeId { get; set; }
        public string WorkTypeName { get; set; } =string.Empty;


        [Display(Name = "Какой материал в работе")]
        [ForeignKey(nameof(MaterialId))]
        public int MaterialId { get; set; }
        public virtual Material? Material { get; set; }
    }
}
