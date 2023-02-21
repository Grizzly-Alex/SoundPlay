namespace SoundPlay.Core.Exceptions;

public sealed class ObjectNotFoundException:Exception
{
    public ObjectNotFoundException(string message) : base(message) { }
}