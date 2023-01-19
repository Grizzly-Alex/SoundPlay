using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SoundPlay.BLL.Interfaces;

namespace SoundPlay.BLL.Utility
{
	public sealed class ContentLoader : IContentLoader
	{
		public string? FileUrl { get; private set; }
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly string _webRootPath;

		public ContentLoader(IWebHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
			_webRootPath = _hostEnvironment.WebRootPath;
		}

		public void UploadFile(IFormFileCollection formFiles, string path)
		{
			string upload = string.Concat(_webRootPath, path); 
			string fileName = Guid.NewGuid().ToString();
			string extension = Path.GetExtension(formFiles[0].FileName);
			string fullFileName = string.Concat(fileName, extension);

			FileUrl = fullFileName;

			using (var fileStream = new FileStream(Path.Combine(upload, fullFileName), FileMode.Create))
			{
				formFiles[0].CopyTo(fileStream);
			}
		}
	}
}
