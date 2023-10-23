using VardabitCore.Business.Models.Requests.SiparisRequests;
using VardabitCore.Business.Models.Responses.SiparisResponses;
using VardabitCore.Common.Business;

namespace VardabitCore.Business.Interfaces
{
	public interface ISiparisService
	{
        Task<ServiceResult<List<ListSiparisResponse>>> GetAll();
        Task<ServiceResult<List<ListSiparisResponse>>> GetAll(long musteriID);
        Task<ServiceResult<GetSiparisResponse>> GetSiparis(int versiyonID);
        Task<ServiceResult> AddSiparis(AddSiparisRequest request);
        Task<ServiceResult> EditSiparis(EditSiparisRequest request);
        Task<ServiceResult> DeleteSiparis(DeleteSiparisRequest request);
    }
}