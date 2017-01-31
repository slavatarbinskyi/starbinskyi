using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApp.Helpers
{
	public class ImageHelper
	{
		public ImageHelper()
		{

		}
		public void SaveImage(string id, HttpPostedFileBase image, string path)
		{
			Directory.CreateDirectory(path + id);
			var pathToFile = path + id + "/photo.jpeg";
			image.SaveAs(pathToFile);
		}
		public string GetImagePath(string id)
		{
			var path = ConfigurationManager.AppSettings["cdn"];
			return path + id + "/photo.jpeg";
		}

	}
}