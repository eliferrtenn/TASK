using System;
namespace VardabitCore.Business.Models.Responses.AccountResponses
{
	public class GetUserResponse
	{
        public long ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}