using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Exceptions.CategoryExceptions;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriesController : ControllerBase
{
    readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _categoryService.GetById(id);
        
        return Ok(category);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_categoryService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto dto)
    {
        return Ok(await _categoryService.CreateAsync(dto));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryDto dto)
    {
        await _categoryService.UpdateAsync(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _categoryService.DeleteAsync(id);
        return NoContent();
    }

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        await _categoryService.SoftDeleteAsync(id);
        return NoContent();
    }
    
    
}