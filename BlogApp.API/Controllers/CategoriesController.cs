using AutoMapper;
using BlogApp.Business.Exceptions.CategoryExceptions;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
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
        return Ok();
    }
    
}