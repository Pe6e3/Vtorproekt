using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models
{
    public class Bale
    {
        [Key] public int BaleId { get; set; }
        public int? EmployeeId { get; set; }
        public int? MaterialId { get; set; }

    }
}
