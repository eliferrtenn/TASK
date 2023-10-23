using Microsoft.AspNetCore.Mvc;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.SiparisRequests;
using VardabitCore.Common.BaseController;

namespace VardabitCore.API.Controllers
{
	public class SiparisController : APIBaseController
    {
        private readonly ISiparisService _siparisService;

        public SiparisController(ISiparisService siparisService)
        {
            _siparisService = siparisService;
        }

        /// <summary>
        /// Yeni bir sipariş ekler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(AddSiparisRequest request)
        {
            var result = await _siparisService.AddSiparis(request);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir siparişi günceller
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(EditSiparisRequest request)
        {
            var result = await _siparisService.EditSiparis(request);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir siparişi siler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteSiparisRequest request)
        {
            var result = await _siparisService.DeleteSiparis(request);
            return Ok(result);
        }

        /// <summary>
        /// Tüm siparişleri listeler
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _siparisService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir siparişi listeler
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetSiparis(int siparisID)
        {
            var result = await _siparisService.GetSiparis(siparisID);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir müşteriye ait tüm siparişleri listeler
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllSiparisForMusteri(long musteriID)
        {
            var result = await _siparisService.GetAll(musteriID);
            return Ok(result);
        }
    }
}