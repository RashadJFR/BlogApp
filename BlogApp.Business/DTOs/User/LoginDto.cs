using FluentValidation;

namespace BlogApp.Business.DTOs.User;

public record LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .NotNull()
            .WithMessage("Username is required");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .NotNull()
            .WithMessage("Password is required")
            .MinimumLength(6)
            .WithMessage("Username or Password is invalid");
    }
}