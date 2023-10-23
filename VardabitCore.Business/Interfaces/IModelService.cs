using VardabitCore.Business.Models.Requests.ModelRequests;
using VardabitCore.Business.Models.Responses.ModelResponses;
using VardabitCore.Common.Business;

namespace VardabitCore.Business.Interfaces
{
	public interface IModelService
	{
        Task<ServiceResult<List<ListModelResponses>>> GetAll(long markaID);
        Task<ServiceResult<GetModelResponse>> GetModel(int modelID);
        Task<ServiceResult> AddModel(AddModelRequest request,long markaID);
        Task<ServiceResult> EditModel(EditModelRequest request);
        Task<ServiceResult> DeleteModel(DeleteModelRequest request);
    }
}