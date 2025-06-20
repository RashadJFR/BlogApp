using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BlogApp.Business.DTOs.User;
using BlogApp.Business.Exceptions.UserExceptions;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BlogApp.Business.Services.Implementations;

public class UserService: IUserService
{
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;
    readonly IConfiguration _config;

    public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration config)
    {
        _userManager = userManager;
        _mapper = mapper;
        _config = config;
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

    public async Task<string> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.Username);

        if (user == null)
        {
            throw new UserLoginFailedException();
        }
        
        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result)
        {
            throw new UserLoginFailedException();
        }

        var _claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName)

        };
        
        SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecurityKey"]));

        SigningCredentials _signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtToken = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: _claims,
            signingCredentials: _signingCredentials,
            expires: DateTime.Now.AddMinutes(60)
            );
        
        string token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        
        return token;
    }
}