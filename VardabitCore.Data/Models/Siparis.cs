using System.ComponentModel.DataAnnotations.Schema;
using VardabitCore.Common.EntityModel;

namespace VardabitCore.Data.Models
{
    [Table("Siparis")]
    public class Siparis : EntityBase
	{
        public DateTime SiparisTarih { get; set; }
        public float ToplamFiyat { get; set; }
        public int SiparisDurum { get; set; }
        public int SiparisKalem { get; set; }
        public long MusteriID { get; set; }
    }
}