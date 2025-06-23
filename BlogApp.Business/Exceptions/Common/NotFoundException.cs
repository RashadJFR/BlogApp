using BlogApp.Business.Exceptions.Base;

namespace BlogApp.Business.Exceptions.Common;

public class NotFoundException<T> : Exception, IBaseException where T : class
{
    public string ErrorMessage { get; }
    public int StatusCode { get; }

    public NotFoundException() 
    {
        ErrorMessage = "Not found";
        StatusCode = 404;
    }

    public NotFoundException(string message):base(message){}
    
}