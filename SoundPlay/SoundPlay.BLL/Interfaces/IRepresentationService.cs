namespace SoundPlay.BLL.Interfaces;

public interface IRepresentationService
{
	public Task<IEnumerable<SelectListItem>> GetSelectList<TEntity>() where TEntity : Entity;
}
