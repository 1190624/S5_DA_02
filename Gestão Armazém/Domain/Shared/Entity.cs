namespace DDDSample1.Domain.Shared
{
    public abstract class Entity<TEntityId>
    where TEntityId: EntityId
    {
         public TEntityId Id { get;  protected set; }
    }
}