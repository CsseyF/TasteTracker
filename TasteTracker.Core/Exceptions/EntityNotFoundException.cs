namespace TasteTracker.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base("A entidade solicitada não foi encontrada")
        {
        }

        public EntityNotFoundException(string entity) : base($"A entidade do tipo {entity} solicitada não foi encontrada")
        {
        }
    }
}
