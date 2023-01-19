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

		public async Task UploadFile(IFormFileCollection files, string path)
		{
			if (files.Count != 0)
			{
				string upload = string.Concat(_webRootPath, path);

				foreach (var file in files)
				{
					string fileName = Guid.NewGuid().ToString();
					string extension = Path.GetExtension(file.FileName);
					string fullFileName = string.Concat(fileName, extension);

					using (var fileStream = new FileStream(Path.Combine(upload, fullFileName), FileMode.Create))
					{
						await file.CopyToAsync(fileStream);
					}
				}
			}


				//string upload = string.Concat(_webRootPath, path);

				//string[] paths = new string[formFiles.Count];

				//for (int i = 0; i < paths.Length; i++)
				//{
				//	string fileName = Guid.NewGuid().ToString();
				//	string extension = Path.GetExtension(formFiles[i].FileName);
				//	string fullFileName = string.Concat(fileName, extension);
				//	paths[i] = fullFileName;
				//}

				//using (var fileStream = new FileStream(Path.Combine(upload, fullFileName), FileMode.Create))
				//{
				//		formFiles[0].CopyTo(fileStream);
				//}

			


			//if (formFiles.Count != 0)
			//{
			//	string upload = string.Concat(_webRootPath, path);
			//	string fileName = Guid.NewGuid().ToString();
			//	string extension = Path.GetExtension(formFiles[0].FileName);
			//	string fullFileName = string.Concat(fileName, extension);

			//	FileUrl = fullFileName;

			//	using (var fileStream = new FileStream(Path.Combine(upload, fullFileName), FileMode.Create))
			//	{
			//		formFiles[0].CopyTo(fileStream);
			//	}
			//}
		}

		public void RemoveFile(string contentPath, string nameFile)
		{
			try
			{			
				string _filePath = Path.Combine(string.Concat(_webRootPath, contentPath), nameFile);
				
				if (File.Exists(_filePath))
				{
					File.Delete(_filePath);
				}
			}

			catch (IOException ex)
			{
				_logger.LogError(ex, $"File not found");
			}
		}
	}
}
