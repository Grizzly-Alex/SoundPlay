using Microsoft.AspNetCore.Http;


namespace SoundPlay.BLL.Interfaces
{
	public interface IContentLoader
	{
		public List<string> NameFiles { get; }
		public void UploadFiles(IFormFileCollection files, string path);
		public void RemoveFile(string contentPath, string nameFile);
	}
}
