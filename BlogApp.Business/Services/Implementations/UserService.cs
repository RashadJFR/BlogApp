using System.Text;
using AutoMapper;
using BlogApp.Business.DTOs.User;
using BlogApp.Business.Exceptions.UserExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Business.Services.Implementations;

public class UserService: IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;

    public UserService(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }


    public async Task Register(RegisterDto registerDto)
    {
        if (await _userManager.FindByEmailAsync(registerDto.Email) != null)
        {
            throw new UserRegisterException("Email already exists");
        }

        if (await _userManager.FindByNameAsync(registerDto.UserName) != null)
        {
            throw new UserRegisterException("Username already exists");
        }
        
        var user = _mapper.Map<AppUser>(registerDto);
        
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var error in result.Errors)
            {
                sb.AppendLine(error.Description + " ");
            }
            
            throw new UserRegisterException(sb.ToString());
        }
    }
}