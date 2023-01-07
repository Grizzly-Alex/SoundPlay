namespace SoundPlay.DAL.Repository.Interfaces
{
	public interface IUnitOfWork
	{
		Task SaveChangesAsync();
	}
}
