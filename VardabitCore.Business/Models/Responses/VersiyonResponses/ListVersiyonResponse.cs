using System;
namespace VardabitCore.Business.Models.Responses.VersiyonResponses
{
	public class ListVersiyonResponse
	{
        public long ID { get; set; }
        public float DepolamaKapasitesi { get; set; }
        public float Fiyat { get; set; }
        public string StokDurumu { get; set; }
        public long ModelID { get; set; }
    }
}