using System;
using FluentValidation;
using Microsoft.Extensions.Localization;
using VardabitCore.Resources;

namespace VardabitCore.Business.Models.Requests.AccountRequests
{
	public class EditUserRequest
	{
		public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
	}
    public class EditUserRequestValidator : AbstractValidator<EditUserRequest>
    {
        public EditUserRequestValidator(IStringLocalizer<CommonResource> _localizer)
        {
            RuleFor(x => x.Email).NotNull().WithMessage(x => _localizer["ValidationForRequired"]);
            RuleFor(x => x.Password).NotNull().WithMessage(x => _localizer["ValidationForRequired"]);
        }
    }
}