using System;
using FluentValidation;

namespace NotifySlackOfWebMeetingsAdmin.Apis.entities
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // ユーザー名が未指定の場合はNGとする。
            RuleFor(user => user.Name).NotNull().NotEmpty().WithMessage("name is null or empty");
            // EmailAddressが未指定の場合はNGとする。
            RuleFor(user => user.EmailAddress).NotNull().NotEmpty().WithMessage("webhookUrl is null or empty");
        }
    }
}