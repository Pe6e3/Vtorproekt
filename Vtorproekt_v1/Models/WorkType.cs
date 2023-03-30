using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models
{
    public class WorkType
    {
        [Key] public int WorkTypeId { get; set; }
        public string WorkTypeName { get; set; } =string.Empty;
    }
}
