namespace BlogApp.Business.Exceptions.Base;

public interface IBaseException
{
    string ErrorMessage { get; }
    int StatusCode { get; }
}