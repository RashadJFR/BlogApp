namespace BlogApp.Business.DTOs.Category;

public record GetAllCategoryDto
{
    public IQueryable<GetCategoryDto> Categories { get; init; }
}