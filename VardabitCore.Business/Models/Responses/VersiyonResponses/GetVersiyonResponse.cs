using System;
namespace VardabitCore.Business.Models.Responses.VersiyonResponses
{
	public class GetVersiyonResponse
	{
        public float DepolamaKapasitesi { get; set; }
        public float Fiyat { get; set; }
        public string StokDurumu { get; set; }
	public string ModelAd { get; set; }	
    }
}
