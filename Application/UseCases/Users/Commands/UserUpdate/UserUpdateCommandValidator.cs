using Domain.Entities.EventManagement.Users;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public class UserUpdateCommandValidator : AbstractValidator<UserUpdateCommand>
    {
        public UserUpdateCommandValidator()
        {
            RuleFor(r => r.UserTypeId)
                .NotEqual(Guid.Empty).WithMessage(UserErrors.Required.UserTypeId);
            RuleFor(r => r.Username)
                .NotEmpty().WithMessage(UserErrors.Required.Username)
                .Matches(UserRegexes.Username).WithMessage(UserErrors.Format.Username);
            RuleFor(r => r.Email)
                .NotEmpty().WithMessage(UserErrors.Required.Email)
                .Matches(UserRegexes.Email).WithMessage(UserErrors.Format.Email);
            RuleFor(r => r.Password)
                .NotEmpty().WithMessage(UserErrors.Required.Password)
                .Matches(UserRegexes.Password).WithMessage(UserErrors.Format.Password);
            RuleFor(r => r.PasswordConfirm)
                .NotEmpty().WithMessage(UserErrors.Required.PasswordConfirmed)
                .Equal(r => r.Password).WithMessage(UserErrors.BadContent.PasswordConfirmed);
        }
    }
}
