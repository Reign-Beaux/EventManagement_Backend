namespace Application.UseCases.Auth.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(r => r.UsernameOrEmail)
                .NotEmpty()
                .WithName("Usuario o Contraseña");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithName("Contraseña");
        }
    }
}
