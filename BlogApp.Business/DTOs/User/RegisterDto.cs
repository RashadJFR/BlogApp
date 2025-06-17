using FluentValidation;

namespace BlogApp.Business.DTOs.User;

public record RegisterDto
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3)
            .MaximumLength(50);
        RuleFor(x=>x.Surname)
            .NotNull().WithMessage("Surname is required")
            .NotEmpty().WithMessage("Surname is required")
            .MinimumLength(3)
            .MaximumLength(100);
        RuleFor(x=>x.UserName)
            .NotNull().WithMessage("UserName is required")
            .NotEmpty().WithMessage("UserName is required")
            .MinimumLength(3)
            .MaximumLength(50);
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email is required")
            .NotEmpty().WithMessage("Email is required")
            .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$").WithMessage("Email is invalid");
        RuleFor(x => x.Password)
            .NotNull().WithMessage("Password is required")
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(3);
        RuleFor(x=>x.ConfirmPassword)
            .NotNull().WithMessage("ConfirmPassword is required")
            .NotEmpty().WithMessage("ConfirmPassword is required")
            .MinimumLength(3)
            .Equal(x=>x.Password).WithMessage("Passwords do not match");


    }
}