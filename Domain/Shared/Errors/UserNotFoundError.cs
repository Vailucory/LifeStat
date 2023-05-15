namespace LifeStat.Domain.Shared.Errors;
public class UserNotFoundError : Error
{
    public UserNotFoundError(string propertyValue, string propertyName = "Id") 
        : base(propertyName, $"User not found by {propertyName} equals {propertyValue}.")
    {
    }

    public UserNotFoundError(int propertyValue, string propertyName = "Id") 
        : this(propertyValue.ToString(), propertyName) 
    {
    }

    public UserNotFoundError(Guid propertyValue, string propertyName = "Id")
        : this(propertyValue.ToString(), propertyName)
    {
    }
}
