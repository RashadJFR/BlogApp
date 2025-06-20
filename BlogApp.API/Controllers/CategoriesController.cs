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
    public IActionResult Get(int id)
    {
        try
        {
            return Ok(_categoryService.GetById(id));
        }
        catch (CategoryNullException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            return Ok(_categoryService.GetAll());
        }
        catch (CategoryNullException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryDto dto)
    {
        try
        {
            return Ok(await _categoryService.CreateAsync(dto));
        }
        catch (CategoryNameExistException e)
        {
            return StatusCode(StatusCodes.Status409Conflict, e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateCategoryDto dto)
    {
        try
        {
            await _categoryService.UpdateAsync(dto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("SoftDelete/{id}")]
    public async Task<IActionResult> SoftDelete(int id)
    {
        try
        {
            await _categoryService.SoftDeleteAsync(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}