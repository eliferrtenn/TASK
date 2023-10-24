using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.ModelRequests;
using VardabitCore.Business.Models.Responses.MarkaResponses;
using VardabitCore.Business.Models.Responses.ModelResponses;
using VardabitCore.Common.Business;
using VardabitCore.Data.Context;
using VardabitCore.Data.Models;
using VardabitCore.Resources;

namespace VardabitCore.Business.Services
{
    public class ModelService : BaseService, IModelService
    {
        public ModelService(VardabitContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IStringLocalizer<CommonResource> localizer) : base(context, configuration, httpContext, localizer)
        {
        }

        public async Task<ServiceResult> AddModel(AddModelRequest request, long markaID)
        {
            var result = new ServiceResult();
            var model = new Model();
            model.ModelAd = request.ModelAd;
            model.MarkaID = request.MarkaID;
            _context.Model.Add(model);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordAdded"]);
            return result;
        }

        public async Task<ServiceResult> DeleteModel(DeleteModelRequest request)
        {
            var result = new ServiceResult();
            var technic = await _context.Model.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (technic == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            technic.isDeleted = true;
            _context.Model.Update(technic);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordDeleted"]);
            return result;
        }

        public async Task<ServiceResult> EditModel(EditModelRequest request)
        {
            var result = new ServiceResult();
            var model = await _context.Model.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (model == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            model.ModelAd = request.ModelAd;
            model.MarkaID = request.MarkaID;
            _context.Model.Update(model);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordUpdated"]);
            return result;
        }

        public async Task<ServiceResult<List<ListModelResponses>>> GetAll(long markaID)
        {
            var result = new ServiceResult<List<ListModelResponses>>();
            if (_context.Model.Count() == 0)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            var model = await(from technic in _context.Model
                              join marka in _context.Marka on technic.MarkaID equals marka.ID
                              where technic.isDeleted == false && technic.isActive == true && technic.MarkaID==markaID
                              select new ListModelResponses
                              {
                                  ModelAd = technic.ModelAd,
                                  MarkaAd = marka.MarkaAd,
                              }).ToListAsync();

            result.Data = model;
            return result;
        }

        public async Task<ServiceResult<GetModelResponse>> GetModel(int modelID)
        {
            var result = new ServiceResult<GetModelResponse>();
            var model = await(from technic in _context.Model
                              join marka in _context.Marka on technic.MarkaID equals marka.ID
                              where technic.ID == modelID
                              select new GetModelResponse
                              {
                                  ModelAd = technic.ModelAd,
                                  MarkaAd = marka.MarkaAd,
                              }).FirstOrDefaultAsync();
            if (model == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            result.Data = model;
            return result;
        }
    }
}

