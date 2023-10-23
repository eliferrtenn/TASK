using System.ComponentModel.DataAnnotations.Schema;
using VardabitCore.Common.EntityModel;

namespace VardabitCore.Data.Models
{
    [Table("Versiyon")]
    public class Versiyon : EntityBase
	{
        public float DepolamaKapasitesi { get; set; }
        public float Fiyat { get; set; }
        public string StokDurumu { get; set; }
        public long ModelID { get; set; }
    }
}