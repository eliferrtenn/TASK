using Microsoft.AspNetCore.Mvc;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.VersiyonRequests;
using VardabitCore.Common.BaseController;

namespace VardabitCore.API.Controllers
{
	public class VersiyonController : APIBaseController
	{
        private readonly IVersiyonService _versiyonService;

        public VersiyonController(IVersiyonService versiyonService)
        {
            _versiyonService = versiyonService;
        }

        /// <summary>
        /// Yeni bir versiyon ekler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(AddVersiyonRequest request,long modelID)
        {
            var result = await _versiyonService.AddVersiyon(request,modelID);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir versiyonu düzenler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(EditVersiyonRequest request)
        {
            var result = await _versiyonService.EditVersiyon(request);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir versiyonu siler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteVersiyonRequest request)
        {
            var result = await _versiyonService.DeleteVersiyon(request);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir modele ait versiyonları listeler
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(long modelID)
        {
            var result = await _versiyonService.GetAll(modelID);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir versiyonu gösterir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetVersiyon(int versiyonID)
        {
            var result = await _versiyonService.GetVersiyon(versiyonID);
            return Ok(result);
        }
    }
}

