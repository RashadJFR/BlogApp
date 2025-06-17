namespace BlogApp.Business.Exceptions.UserExceptions;

public class UserRegisterException:Exception
{
    public UserRegisterException():base("Register failed"){}
    public UserRegisterException(string message):base(message){}
}