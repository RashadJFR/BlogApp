using FluentValidation;

namespace BlogApp.Business.DTOs.Category;

public record UpdateCategoryDto
{
    public int Id { get; set; }
    public string Name { get; init; }
}

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id is required");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .NotNull()
            .WithMessage("Name is required")
            .MaximumLength(20)
            .WithMessage("Name is need to be less than 20 characters");
    }
}