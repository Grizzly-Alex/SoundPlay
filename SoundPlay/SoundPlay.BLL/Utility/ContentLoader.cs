using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SoundPlay.BLL.Interfaces;

namespace SoundPlay.BLL.Utility
{
	public sealed class ContentLoader : IContentLoader
	{
		public string? FileUrl { get; private set; }
		private string? _filePath;	
		private readonly string _webRootPath;
		private readonly ILoggerAdapter<ContentLoader> _logger;

		private readonly IWebHostEnvironment _hostEnvironment;

		public ContentLoader(
			IWebHostEnvironment hostEnvironment,
			ILoggerAdapter<ContentLoader> logger)
		{
			_hostEnvironment = hostEnvironment;
			_webRootPath = _hostEnvironment.WebRootPath;
			_logger = logger;
		}

		public void UploadFile(IFormFileCollection formFiles, string path)
		{
			if (formFiles.Count == 0) return;

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

		public void RemoveFile(string contentPath, string nameFile)
		{
			try
			{
				_filePath = Path.Combine(_webRootPath, contentPath, nameFile);

				if (File.Exists(_filePath))
				{
					File.Delete(_filePath);
					_filePath = string.Empty;
				}
			}
			catch (IOException ex)
			{
				_logger.LogError(ex, $"File not found, {_filePath}");
				_filePath = string.Empty;
			}
		}
	}
}
