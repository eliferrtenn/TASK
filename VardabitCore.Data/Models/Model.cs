using System.ComponentModel.DataAnnotations.Schema;
using VardabitCore.Common.EntityModel;

namespace VardabitCore.Data.Models
{
    [Table("Model")]
    public class Model : EntityBase
	{
        public string ModelAd { get; set; }
        public long MarkaID { get; set; }
    }
}