namespace SoundPlay.Core.Exceptions;

public class BasketNotFoundException : Exception
{
	public BasketNotFoundException(int basketId) : base($"Basket not found with id {basketId}")
	{
	}
}
