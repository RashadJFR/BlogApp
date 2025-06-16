using FluentValidation;
using FluentValidation.Validators;

namespace BlogApp.Business.DTOs.Category;

public record CreateCategoryDto
{
    public string Name { get; set; }
}

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .NotNull()
            .WithMessage("Name is required")
            .MaximumLength(20)
            .WithMessage("Name must not exceed 20 characters");
            
    }
}