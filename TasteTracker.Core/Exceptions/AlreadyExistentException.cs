namespace TasteTracker.Core.Exceptions
{
    public class AlreadyExistentException : Exception
    {
        public AlreadyExistentException(string property) : base($"A entidade não foi criada, pois já existe outra entidade com o mesmo {property}")
        {
        }
    }
}
