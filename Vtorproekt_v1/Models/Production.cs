using System.ComponentModel.DataAnnotations;

namespace Vtorproekt.Models
{
    public class Production
    {
        [Key] public int ProductionId { get; set; }
        public int WorkTypeId { get; set; }
        public int BaleId { get; set; }

        [Range(10, 1000, ErrorMessage = "Недопустимый вес (от 10 до 1000кг)")]
        public double Weight { get; set; }
        public int StorageId { get; set; }

        [DisplayFormat(DataFormatString = "{dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly ProduceDate { get; set; }

        [DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = true)]
        public TimeOnly ProduceTime { get; set; }
        public int TaxId { get; set; }
        public double ProducePayment { get; set; }
        public int StoragerId { get; set; }



        public virtual Material? Material { get; set; }  
        public virtual Employee? Producer { get; set; }  // Рабочий, который произвел сырье
        public virtual WorkType? WorkType { get; set; }
        public virtual Storage? Storage { get; set; }
        public virtual Tax? TaxValue { get; set; }
        public virtual Tax? Limit1 { get; set; }
        public virtual Tax? Limit2 { get; set; }
        public virtual Tax? Limit3 { get; set; }
        public virtual Tax? Multi1 { get; set; }
        public virtual Tax? Multi2 { get; set; }
        public virtual Tax? Multi3 { get; set; }

        public virtual Employee? Storekeeper  { get; set; } // Кладовщик, который принял сырье у рабочего и провел операцию в базе


    }
}
