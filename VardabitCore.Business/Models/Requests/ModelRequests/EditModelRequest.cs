using System;
namespace VardabitCore.Business.Models.Requests.ModelRequests
{
	public class EditModelRequest
	{
        public int ID { get; set; }
        public string ModelAd { get; set; }
        public long MarkaID { get; set; }
    }
}