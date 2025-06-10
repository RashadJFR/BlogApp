namespace BlogApp.Business.Exceptions.Common;

public class NegativeIdException : Exception
{
    public NegativeIdException():base("Id 0 ve ya menfi ola bilmez")
    {
        
    }

    public NegativeIdException(string message) : base(message)
    {
        
    }
    
}