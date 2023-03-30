using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models
{
    public class WorkType
    {
        [Display (Name ="Вид работы")]
        [Key] public int WorkTypeId { get; set; }
        public string WorkTypeName { get; set; } =string.Empty;
    }
}
