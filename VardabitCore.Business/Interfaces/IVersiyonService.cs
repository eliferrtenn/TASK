using VardabitCore.Business.Models.Requests.VersiyonRequests;
using VardabitCore.Business.Models.Responses.VersiyonResponses;
using VardabitCore.Common.Business;

namespace VardabitCore.Business.Interfaces
{
	public interface IVersiyonService
    {
        Task<ServiceResult<List<ListVersiyonResponse>>> GetAll(long modelID);
        Task<ServiceResult<GetVersiyonResponse>> GetVersiyon(int versiyonID);
        Task<ServiceResult> AddVersiyon(AddVersiyonRequest request,long modelID);
        Task<ServiceResult> EditVersiyon(EditVersiyonRequest request);
        Task<ServiceResult> DeleteVersiyon(DeleteVersiyonRequest request);
    }
}