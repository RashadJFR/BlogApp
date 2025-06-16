namespace BlogApp.Business.Exceptions.CategoryExceptions;

public class CategoryNameExistException: Exception
{
    public CategoryNameExistException():base("Bele adda category var"){}
    public CategoryNameExistException(string message): base(message){}
}