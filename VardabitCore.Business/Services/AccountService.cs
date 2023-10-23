using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using VardabitCore.Business.Interfaces;
using VardabitCore.Business.Models.Requests.AccountRequests;
using VardabitCore.Business.Models.Responses.AccountResponses;
using VardabitCore.Common.Business;
using VardabitCore.Common.Helper;
using VardabitCore.Common.JwtModels;
using VardabitCore.Data.Context;
using VardabitCore.Data.Models;
using VardabitCore.Resources;

namespace VardabitCore.Business.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(VardabitContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IStringLocalizer<CommonResource> localizer) : base(context, configuration, httpContext, localizer)
        {
        }

        public async Task<ServiceResult> RegisterUser(RegisterRequest request)
        {
            var result = new ServiceResult();
            var user = new User();
            user.Email = request.Email;
            user.Password = request.Password;
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordAdded"]);
            return result;
        }

        public async Task<ServiceResult> EditUser(EditUserRequest request)
        {
            var result = new ServiceResult();
            var technicalServiceDemand = await _context.User.FirstOrDefaultAsync(x => x.ID == CurrentUserID);
            if (technicalServiceDemand == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            technicalServiceDemand.Email = request.Email;
            technicalServiceDemand.Password = request.Password;
            _context.User.Update(technicalServiceDemand);
            await _context.SaveChangesAsync();
            result.SetSuccess(_localizer["RecordUpdated"]);
            return result;
        }

        public async Task<ServiceResult<GetUserResponse>> GetUser()
        {
            var result = new ServiceResult<GetUserResponse>();
            var technics = await (from technic in _context.User
                                  where technic.ID == CurrentUserID
                                  select new GetUserResponse
                                  {
                                      ID = technic.ID,
                                      Email = technic.Email,
                                      Password = technic.Password
                                  }).FirstAsync();
            if (technics == null)
            {
                result.SetError(_localizer["RecordNotFound"]);
                return result;
            }
            result.Data = technics;
            return result;
        }

        public async Task<ServiceResult<Token>> SignIn(LoginRequest request)
        {
            var result = new ServiceResult<Token>();
            var member = await _context.User.FirstOrDefaultAsync(x => x.Email == request.Email && x.Password==request.Password);
            if (member == null)
            {
                result.SetError("Kullanıcı bulunamadı.");
                return result;
            }

            CustomTokenHandler tokenHandler = new(_configuration);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, member.ID.ToString()),
                new Claim(ClaimTypes.Email, member.Email)
             };
            var token = tokenHandler.CreateAccessToken(claims);
            result.Data = token;
            return result;
        }
    }
}