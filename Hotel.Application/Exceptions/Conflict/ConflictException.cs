namespace Hotel.Application.Exceptions.Conflict
{
    public abstract class ConflictException : Exception
    {
        protected ConflictException( string message ) : base( message )
        { }
    }
}
