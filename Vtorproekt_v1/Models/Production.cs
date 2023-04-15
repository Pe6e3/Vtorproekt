using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VtorP.Models
{
    public class Production
    {
        [Key]
        public int ProductionId { get; set; }
        
        [Display(Name = "Номер тюка/бэга")]
        [ForeignKey("Bale")]
        public int BaleId { get; set; }



        [Display(Name = "Вес тюка/бэга")]
        [Range(10, 1000, ErrorMessage = "Недопустимый вес (от 10 до 1000кг)")]
        public double Weight { get; set; }


        [Display(Name = "Склад")]
        [ForeignKey("Storage")]
        public int StorageId { get; set; }


        [Display (Name ="Дата и время производства")]
        //[DisplayFormat(DataFormatString = "{yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]  С этой строкой ошибка в Edit
        public DateTime ProduceDate { get; set; }


        [Display(Name = "Тариф")]
        public int TaxId { get; set; } = 1;



        public virtual Material? Material { get; set; }
        public virtual Storage? Storage { get; set; }
        public virtual Tax? Tax { get; set; }
        public virtual WorkType? WorkType { get; set; }
        public virtual Employee? Producer { get; set; }


        public Production()
        {
            TaxId = 1;
        }





    }
}