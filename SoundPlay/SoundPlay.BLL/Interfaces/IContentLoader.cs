using Microsoft.AspNetCore.Http;


namespace SoundPlay.BLL.Interfaces
{
	public interface IContentLoader
	{
		public string? FileUrl { get; }
		public void UploadFile(IFormFile file, string path);
	}
}
