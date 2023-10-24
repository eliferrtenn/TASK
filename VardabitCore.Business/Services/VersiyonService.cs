using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.VersiyonRequests;
using VardabitCore.Business.Models.Responses.VersiyonResponses;
using VardabitCore.Common.Business;
using VardabitCore.Data.Context;
using VardabitCore.Data.Models;
using VardabitCore.Resources;

namespace VardabitCore.Business.Services
{
    public class VersiyonService : BaseService, IVersiyonService
    {
        public VersiyonService(VardabitContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IStringLocalizer<CommonResource> localizer) : base(context, configuration, httpContext, localizer)
        {
        }

        public async Task<ServiceResult> AddVersiyon(AddVersiyonRequest request, long modelID)
        {
            var result = new ServiceResult();
            var versiyon = new Versiyon();
            versiyon.DepolamaKapasitesi = request.DepolamaKapasitesi;
            versiyon.Fiyat = request.Fiyat;
            versiyon.StokDurumu = request.StokDurumu;
            versiyon.ModelID = modelID;
            _context.Versiyon.Add(versiyon);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordAdded"]);
            return result;
        }

        public async Task<ServiceResult> DeleteVersiyon(DeleteVersiyonRequest request)
        {
            var result = new ServiceResult();
            var technic = await _context.Versiyon.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (technic == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            technic.isDeleted = true;
            _context.Versiyon.Update(technic);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordDeleted"]);
            return result;
        }

        public async Task<ServiceResult> EditVersiyon(EditVersiyonRequest request)
        {
            var result = new ServiceResult();
            var versiyon = await _context.Versiyon.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (versiyon == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            versiyon.DepolamaKapasitesi = request.DepolamaKapasitesi;
            versiyon.Fiyat = request.Fiyat;
            versiyon.StokDurumu = request.StokDurumu;
            versiyon.ModelID = request.ModelID;
            _context.Versiyon.Update(versiyon);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordUpdated"]);
            return result;
        }

        public async Task<ServiceResult<List<ListVersiyonResponse>>> GetAll(long modelID)
        {
            var result = new ServiceResult<List<ListVersiyonResponse>>();
            if (_context.Versiyon.Count() == 0)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            var versiyon = await (from technic in _context.Versiyon
                                  join model in _context.Model on technic.ModelID equals model.ID
                                  where technic.isDeleted == false && technic.isActive == true && technic.ModelID == modelID
                                   select new ListVersiyonResponse
                               {
                                   ID = technic.ID,
                                   DepolamaKapasitesi=technic.DepolamaKapasitesi,
                                   Fiyat=technic.Fiyat,
                                   StokDurumu=technic.StokDurumu,
                                   ModelAd = model.ModelAd ,
                               }).ToListAsync();

            result.Data = versiyon;
            return result;
        }

        public async Task<ServiceResult<GetVersiyonResponse>> GetVersiyon(int versiyonID)
        {
            var result = new ServiceResult<GetVersiyonResponse>();
            var versiyon = await (from technic in _context.Versiyon
                               where technic.ID == versiyonID
                               select new GetVersiyonResponse
                               {
                                   ID = technic.ID,
                                   DepolamaKapasitesi = technic.DepolamaKapasitesi,
                                   Fiyat = technic.Fiyat,
                                   StokDurumu = technic.StokDurumu
                               }).FirstOrDefaultAsync();
            if (versiyon == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            result.Data = versiyon;
            return result;
        }
    }
}
