using System;
namespace VardabitCore.Business.Models.Requests.SiparisRequests
{
	public class EditSiparisRequest
	{
        public long ID { get; set; }
        public DateTime SiparisTarih { get; set; }
        public float ToplamFiyat { get; set; }
        public int SiparisDurum { get; set; }
        public int SiparisKalem { get; set; }
        public long MusteriID { get; set; }
    }
}