using BlogApp.Business.Exceptions.Base;

namespace BlogApp.Business.Exceptions.Common;

public class NegativeIdException : Exception, IBaseException
{
    public NegativeIdException():base("Id 0 ve ya menfi ola bilmez")
    {
        ErrorMessage = "Id 0 ve ya menfi ola bilmez";
        StatusCode = 400;
    }

    public NegativeIdException(string message) : base(message)
    {
        
    }

    public string ErrorMessage { get; }
    public int StatusCode { get; }
}