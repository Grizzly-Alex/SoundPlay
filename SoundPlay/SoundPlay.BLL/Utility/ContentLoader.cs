using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SoundPlay.BLL.Interfaces;


namespace SoundPlay.BLL.Utility
{
	public sealed class ContentLoader : IContentLoader
	{
		public string? FileUrl { get; private set; }	
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

		public async Task<List<string>> UploadFile(IFormFileCollection files, string path)
		{
			List<string> fileUrls = new();

			if (files.Count != 0)
			{				
				string upload = string.Concat(_webRootPath, path);

				foreach (var file in files)
				{
					string fileName = Guid.NewGuid().ToString();
					string extension = Path.GetExtension(file.FileName);
					string fullFileName = string.Concat(fileName, extension);

					fileUrls.Add(fullFileName);

					using (var fileStream = new FileStream(Path.Combine(upload, fullFileName), FileMode.Create))
					{
						await file.CopyToAsync(fileStream);
					}
				}
				
				fileUrls.ForEach(value => _logger.LogInformation($"Files {value} added successfully"));
			}

			return fileUrls;
		}

		public void RemoveFile(string contentPath, string nameFile)
		{
			try
			{
				if (nameFile is not null)
				{
					string _filePath = Path.Combine(string.Concat(_webRootPath, contentPath), nameFile);

					if (File.Exists(_filePath))
					{
						File.Delete(_filePath);
					}
				}
			}

			catch (IOException ex)
			{
				_logger.LogError(ex, $"File not found");
			}
		}
	}
}
