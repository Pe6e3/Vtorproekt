using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vtorproekt.Models
{
    public class Production
    {
        [Key]
        public int ProductionId { get; set; }


        [ForeignKey("WorkType")]
        public int WorkTypeId { get; set; }
        public virtual WorkType? WorkType { get; set; }



        [ForeignKey("Bale")]
        public int BaleId { get; set; }
        public virtual Material? Material { get; set; }



        [Range(10, 1000, ErrorMessage = "Недопустимый вес (от 10 до 1000кг)")]
        public double Weight { get; set; }



        [ForeignKey("Storage")]
        public int StorageId { get; set; }
        public virtual Storage? Storage { get; set; }



        [DisplayFormat(DataFormatString = "{hh:mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProduceDate { get; set; }




        [ForeignKey("Tax")]
        public int TaxId { get; set; }
        [ForeignKey("Tax")]        public virtual Tax? TaxValue { get; set; }





       
        [ForeignKey("Employee")]
        public virtual Employee? Producer { get; set; }







    }
}