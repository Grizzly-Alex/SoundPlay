using SoundPlay.DAL.Data;
using SoundPlay.DAL.Repository.Interfaces;
using SoundPlay.DTO.Models;
using System.Runtime.CompilerServices;

namespace SoundPlay.DAL.Repository
{
	public sealed class UnitOfWork : IUnitOfWork
	{
		public Repository<Category> Category { get; private set; }

		private ApplicationDbContext _db;

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new(_db);
		}

		public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
	}
}