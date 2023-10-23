using VardabitCore.Business.Models.Requests.MarkaRequests;
using VardabitCore.Business.Models.Responses.MarkaResponses;
using VardabitCore.Common.Business;


namespace VardabitCore.Business.Interfaces
{
	public interface IMarkaService
	{
        Task<ServiceResult<List<ListMarkaResponses>>> GetAll();
        Task<ServiceResult<GetMarkaResponse>> GetMarka(int markaID);
        Task<ServiceResult> AddMarka(AddMarkaRequest request);
        Task<ServiceResult> EditMarka(EditMarkaRequest request);
        Task<ServiceResult> DeleteMarka(DeleteMarkaRequest request);
    }
}