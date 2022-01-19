namespace VolvoTrucks.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    public Type EntityType { get; set; }
    public object?[] EntityKeys { get; set; }
    
    public EntityNotFoundException(object?[] entityKeys, Type entityType) : base(
        $"Entity of type {nameof(EntityType)} with keys {entityKeys} not found")
    {
        EntityKeys = entityKeys;
        EntityType = entityType;
    }
}