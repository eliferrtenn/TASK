﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System.Security.Claims;
using VardabitCore.Resources;
using VardabitCore.Data.Context;

namespace VardabitCore.Business.Services
{
	public class BaseService
	{
        protected VardabitContext _context;
        protected IConfiguration _configuration;
        protected IHttpContextAccessor _httpContext;
        protected IStringLocalizer<CommonResource> _localizer;


        public BaseService(VardabitContext context, IConfiguration configuration, IHttpContextAccessor httpContext, IStringLocalizer<CommonResource> localizer)
        {
            _context = context;
            _configuration = configuration;
            _httpContext = httpContext;
            _localizer = localizer;
        }
        public int CurrentUserID
        {
            get
            {
                return int.Parse(_httpContext.HttpContext.User.Identities.FirstOrDefault(u => u.IsAuthenticated && u.HasClaim(c => c.Type == ClaimTypes.NameIdentifier))?.FindFirst(ClaimTypes.NameIdentifier).Value);
            }
        }
    }
}