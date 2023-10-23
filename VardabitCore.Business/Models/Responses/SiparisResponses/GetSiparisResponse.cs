using System;
namespace VardabitCore.Business.Models.Responses.SiparisResponses
{
	public class GetSiparisResponse
	{
        public long ID { get; set; }
        public DateTime SiparisTarih { get; set; }
        public float ToplamFiyat { get; set; }
        public int SiparisDurum { get; set; }
        public int SiparisKalem { get; set; }
        public long MusteriID { get; set; }
    }
}