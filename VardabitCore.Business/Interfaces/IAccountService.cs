using VardabitCore.Business.Models.Requests.AccountRequests;
using VardabitCore.Business.Models.Responses.AccountResponses;
using VardabitCore.Common.Business;
using VardabitCore.Common.JwtModels;

namespace VardabitCore.Business.Interfaces
{
	public interface IAccountService
	{
        Task<ServiceResult<Token>> SignIn(LoginRequest request);
        Task<ServiceResult<GetUserResponse>> GetUser();
        Task<ServiceResult> RegisterUser(RegisterRequest request);
        Task<ServiceResult> EditUser(EditUserRequest request);
    }
}