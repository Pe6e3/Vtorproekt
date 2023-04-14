using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtorP.Models
{
    public class WorkType
    {
        [Display (Name ="Вид работы")]
        [Key] public int WorkTypeId { get; set; }
        public string WorkTypeName { get; set; } =string.Empty;


    }
}
