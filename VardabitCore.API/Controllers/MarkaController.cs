using Microsoft.AspNetCore.Mvc;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.MarkaRequests;
using VardabitCore.Common.BaseController;

namespace VardabitCore.API.Controllers
{
    public class MarkaController : APIBaseController
    {
        private readonly IMarkaService _markaService;

        public MarkaController(IMarkaService markaService)
        {
            _markaService = markaService;
        }

        /// <summary>
        /// Yeni bir marka ekler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(AddMarkaRequest request)
        {
            var result = await _markaService.AddMarka(request);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir markayı günceller
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(EditMarkaRequest request)
        {
            var result = await _markaService.EditMarka(request);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir markayı siler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteMarkaRequest request)
        {
            var result = await _markaService.DeleteMarka(request);
            return Ok(result);
        }

        /// <summary>
        /// Tüm markaları listeler
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _markaService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir markayı getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetMarka(int markaID)
        {
            var result = await _markaService.GetMarka(markaID);
            return Ok(result);
        }
    }
}

