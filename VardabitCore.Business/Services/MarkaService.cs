using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.MarkaRequests;
using VardabitCore.Business.Models.Responses.AccountResponses;
using VardabitCore.Business.Models.Responses.MarkaResponses;
using VardabitCore.Common.Business;
using VardabitCore.Data.Context;
using VardabitCore.Data.Models;
using VardabitCore.Resources;

namespace VardabitCore.Business.Services
{
    public class MarkaService : BaseService, IMarkaService
    {
        public MarkaService(VardabitContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IStringLocalizer<CommonResource> localizer) : base(context, configuration, httpContext, localizer)
        {
        }

        public async Task<ServiceResult> AddMarka(AddMarkaRequest request)
        {
            var result = new ServiceResult();
            var marka = new Marka();
            marka.MarkaAd = request.MarkaAd;
            _context.Marka.Add(marka);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordAdded"]);
            return result;
        }

        public async Task<ServiceResult> DeleteMarka(DeleteMarkaRequest request)
        {
            var result = new ServiceResult();
            var technic = await _context.Marka.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (technic == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            technic.isDeleted = true;
            _context.Marka.Update(technic);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordDeleted"]);
            return result;
        }

        public async Task<ServiceResult> EditMarka(EditMarkaRequest request)
        {
            var result = new ServiceResult();
            var marka = await _context.Marka.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (marka == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            marka.MarkaAd = request.MarkaAd;
            _context.Marka.Update(marka);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordUpdated"]);
            return result;
        }

        public async Task<ServiceResult<List<ListMarkaResponses>>> GetAll()
        {
            var result = new ServiceResult<List<ListMarkaResponses>>();
            if (_context.Marka.Count() == 0)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            var marka = await(from technic in _context.Marka
                                 where technic.isDeleted == false && technic.isActive==true 
                                 select new ListMarkaResponses
                                 {
                                     ID = technic.ID,
                                     MarkaAd = technic.MarkaAd,
                                 }).ToListAsync();
            result.Data = marka;
            return result;
        }

        public async Task<ServiceResult<GetMarkaResponse>> GetMarka(int markaID)
        {
            var result = new ServiceResult<GetMarkaResponse>();
            var marka = await(from technic in _context.Marka
                                 where technic.ID == markaID
                                 select new GetMarkaResponse
                                 {
                                     ID = technic.ID,
                                     MarkaAd = technic.MarkaAd,
                                 }).FirstOrDefaultAsync();
            if (marka == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            result.Data = marka;
            return result;
        }
    }
}

