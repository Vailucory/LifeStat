namespace LifeStat.Domain.Shared.Errors;
public class AlreadyExistsError : Error
{
    public AlreadyExistsError(Type entity, string propertyName, string value) 
        : base(propertyName, $"{entity.Name} with {propertyName} equals {value} is already exists in context of user.")
    {
    }
}
