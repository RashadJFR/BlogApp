using BlogApp.Business.DTOs.User;

namespace BlogApp.Business.Services.Interfaces;

public interface IUserService
{
    Task Register(RegisterDto registerDto);
    Task<string> Login(LoginDto loginDto);
}