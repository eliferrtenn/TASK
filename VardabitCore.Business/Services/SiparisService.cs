using System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.SiparisRequests;
using VardabitCore.Business.Models.Responses.SiparisResponses;
using VardabitCore.Common.Business;
using VardabitCore.Data.Context;
using VardabitCore.Data.Models;
using VardabitCore.Resources;

namespace VardabitCore.Business.Services
{
    public class SiparisService : BaseService, ISiparisService
    {
        public SiparisService(VardabitContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IStringLocalizer<CommonResource> localizer) : base(context, configuration, httpContext, localizer)
        {
        }

        public async Task<ServiceResult> AddSiparis(AddSiparisRequest request)
        {
            var result = new ServiceResult();
            var siparis = new Siparis();
            siparis.SiparisTarih = request.SiparisTarih;
            siparis.ToplamFiyat = request.ToplamFiyat;
            siparis.SiparisTarih = request.SiparisTarih;
            siparis.SiparisDurum = request.SiparisDurum;
            siparis.SiparisKalem = request.SiparisKalem;
            siparis.MusteriID = request.MusteriID;
            _context.Siparis.Add(siparis);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordAdded"]);
            return result;
        }

        public async Task<ServiceResult> DeleteSiparis(DeleteSiparisRequest request)
        {
            var result = new ServiceResult();
            var technic = await _context.Siparis.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (technic == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            technic.isDeleted = true;
            _context.Siparis.Update(technic);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordDeleted"]);
            return result;
        }

        public async Task<ServiceResult> EditSiparis(EditSiparisRequest request)
        {
            var result = new ServiceResult();
            var siparis = await _context.Siparis.FirstOrDefaultAsync(x => x.ID == request.ID);
            if (siparis == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            siparis.SiparisTarih = request.SiparisTarih;
            siparis.ToplamFiyat = request.ToplamFiyat;
            siparis.SiparisTarih = request.SiparisTarih;
            siparis.SiparisDurum = request.SiparisDurum;
            siparis.SiparisKalem = request.SiparisKalem;
            siparis.MusteriID = request.MusteriID;
            _context.Siparis.Update(siparis);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordUpdated"]);
            return result; ;
        }

        public async Task<ServiceResult<List<ListSiparisResponse>>> GetAll()
        {
            var result = new ServiceResult<List<ListSiparisResponse>>();
            if (_context.Siparis.Count() == 0)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            var siparis = await (from technic in _context.Siparis
                                 join musteri in _context.Musteri on technic.MusteriID equals musteri.ID
                                 where technic.isDeleted == false && technic.isActive == true
                                 select new ListSiparisResponse
                                 {
                                     SiparisTarih = technic.SiparisTarih,
                                     SiparisKalem = technic.SiparisKalem,
                                     SiparisDurum = technic.SiparisDurum,
                                     ToplamFiyat = technic.ToplamFiyat,
                                     MusteriAd = musteri.FirstName,
                                 }).ToListAsync();

            result.Data = siparis;
            return result;
        }

        public async Task<ServiceResult<List<ListSiparisResponse>>> GetAll(long musteriID)
        {
            var result = new ServiceResult<List<ListSiparisResponse>>();
            if (_context.Siparis.Count() == 0)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            var siparis = await (from technic in _context.Siparis
                                 join musteri in _context.Musteri on technic.MusteriID equals musteri.ID
                                 where technic.isDeleted == false && technic.isActive == true && technic.MusteriID == musteriID
                                 select new ListSiparisResponse
                                 {
                                     SiparisTarih = technic.SiparisTarih,
                                     SiparisKalem = technic.SiparisKalem,
                                     SiparisDurum = technic.SiparisDurum,
                                     ToplamFiyat = technic.ToplamFiyat,
                                     MusteriAd = musteri.FirstName,
                                 }).ToListAsync();

            result.Data = siparis;
            return result;
        }

        public async Task<ServiceResult<GetSiparisResponse>> GetSiparis(int versiyonID)
        {
            var result = new ServiceResult<GetSiparisResponse>();
            var siparis = await (from technic in _context.Siparis
                                 join musteri in _context.Musteri on technic.MusteriID equals musteri.ID
                                 where technic.ID == versiyonID && technic.isDeleted == false
                                 select new GetSiparisResponse
                                 {
                                     SiparisTarih = technic.SiparisTarih,
                                     SiparisKalem = technic.SiparisKalem,
                                     SiparisDurum = technic.SiparisDurum,
                                     ToplamFiyat = technic.ToplamFiyat,
                                     MusteriAd = musteri.FirstName,
                                 }).FirstOrDefaultAsync();
            if (siparis == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            result.Data = siparis;
            return result;
        }
    }
}
