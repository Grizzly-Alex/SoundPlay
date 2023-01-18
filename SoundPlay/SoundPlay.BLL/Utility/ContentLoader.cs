using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SoundPlay.BLL.Interfaces;

namespace SoundPlay.BLL.Utility
{
	public sealed class ContentLoader : IContentLoader
	{
		public string? FileUrl { get; private set; }
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly string _wwwRootPath;

		public ContentLoader(IWebHostEnvironment hostEnvironment)
		{
			_hostEnvironment = hostEnvironment;
			_wwwRootPath = _hostEnvironment.ContentRootPath;	
		}

		public void UploadFile(IFormFile file, string path)
		{
			string fileName = Guid.NewGuid().ToString();
			var uploads = Path.Combine(_wwwRootPath, path);
			var extension = Path.GetExtension(file.FileName);

			FileUrl = path + fileName + extension;

			using (var fileStrims = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
			{
				file.CopyTo(fileStrims);
			}			
		}
	}
}
