namespace LifeStat.Domain.Exceptions;
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string key, Type entityType) : base($"Entity of type {entityType.Name} not found by key: {key}")
    {
    }

    public EntityNotFoundException(int key, Type entityType) : this(key.ToString(), entityType)
    {
    }
}
