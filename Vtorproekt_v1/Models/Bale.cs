using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vtorproekt.Models
{
    public class Bale
    {
        [Key] public int BaleId { get; set; }


        [ForeignKey("EmployeeId")]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }


        [ForeignKey("MaterialId")]
        public int? MaterialId { get; set; }
        public virtual Material? Material { get; set; }

    }
}
