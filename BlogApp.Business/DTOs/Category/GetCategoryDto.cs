namespace BlogApp.Business.DTOs.Category;

public record GetCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}