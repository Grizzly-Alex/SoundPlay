using Microsoft.AspNetCore.Http;


namespace SoundPlay.BLL.Interfaces
{
	public interface IContentLoader
	{
		public string? FileUrl { get; }
		public Task UploadFile(IFormFileCollection files, string path);
		public void RemoveFile(string contentPath, string nameFile);
	}
}
