namespace Hotel.Application.Exceptions.NotFound
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException( string message ) : base( message )
        { }
    }
}