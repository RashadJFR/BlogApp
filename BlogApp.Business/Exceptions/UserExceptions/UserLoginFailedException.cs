namespace BlogApp.Business.Exceptions.UserExceptions;

public class UserLoginFailedException: Exception
{
    public UserLoginFailedException():base("Login failed"){}
    public UserLoginFailedException(string message):base(message){}
}