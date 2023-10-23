using Microsoft.AspNetCore.Mvc;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.ModelRequests;
using VardabitCore.Common.BaseController;

namespace VardabitCore.API.Controllers
{
	public class ModelController : APIBaseController
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        /// <summary>
        /// Markaya yeni bir model ekler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(AddModelRequest request,long markaID)
        {
            var result = await _modelService.AddModel(request,markaID);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir modeli günceller
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(EditModelRequest request)
        {
            var result = await _modelService.EditModel(request);
            return Ok(result);
        }

        /// <summary>
        /// Belirli bir modeli siler
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteModelRequest request)
        {
            var result = await _modelService.DeleteModel(request);
            return Ok(result);
        }

        /// <summary>
        /// Modeldeki tüm veriyi listeler
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(long markaID)
        {
            var result = await _modelService.GetAll(markaID);
            return Ok(result);
        }

        /// <summary>
        /// Model ait belli bir modeli getirir
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetModel(int modelID)
        {
            var result = await _modelService.GetModel(modelID);
            return Ok(result);
        }

    }
}