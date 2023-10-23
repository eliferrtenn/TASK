using System;
using System.ComponentModel.DataAnnotations.Schema;
using VardabitCore.Common.EntityModel;

namespace VardabitCore.Data.Models
{
    [Table("Marka")]
    public class Marka : EntityBase
	{
        public string MarkaAd { get; set; }
    }
}