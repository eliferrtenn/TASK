using System;
using VardabitCore.Common.JwtModels;

namespace VardabitCore.Business.Models.Responses.AccountResponses
{
	public class LoginResponse
	{
        public Token Token { get; set; }
    }
}