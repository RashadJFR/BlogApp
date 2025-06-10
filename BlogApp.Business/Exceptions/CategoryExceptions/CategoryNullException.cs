namespace BlogApp.Business.Exceptions.CategoryExceptions;

public class CategoryNullException:Exception
{
    public CategoryNullException():base("Category tapilmadi!"){}

    public CategoryNullException(string message):base(message)
    {
        
    }
}