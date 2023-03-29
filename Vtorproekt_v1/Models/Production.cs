using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models
{
    public class Production
    {
        [Key] public int ProductionId { get; set; }
        public int WorkTypeId { get; set; }
        public int BaleId { get; set; }
        public double Weight { get; set; }
        public int StorageId { get; set; }
        public DateOnly ProduceDate { get; set; }
        public TimeOnly ProduceTime { get; set; }
        public int TaxId { get; set; }
        public double ProducePayment { get; set; }
        public int StoragerId { get; set; }

    }
}
