using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundPlay.BLL.Interfaces
{
	public interface IContentLoader
	{
		public void UploadFile(IFormFile file, string path);
	}
}
