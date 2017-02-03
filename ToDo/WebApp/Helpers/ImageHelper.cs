using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
		public void SaveImage(string id, string basestring, string path)
		{
			var cleanbase = basestring.Replace("data:image/png;base64,", string.Empty);
			var imgToSave = Base64ToImage(cleanbase);
			var pathToFile = path + id + "/photo.png";
			imgToSave.Save(pathToFile, ImageFormat.Png);
			Directory.CreateDirectory(path + id);
		}
		public void CropAndSavePoints(string id,string path,Image originalImage,int x, int y, int wh)
		{
			var img = CropImage(originalImage,x,y,wh);
			var pathToFile = path + id + "/photo.png";
			img.Save(pathToFile, ImageFormat.Png);
			Directory.CreateDirectory(path + id);
		}
		public string GetImagePath(string id)
		{
			var path = ConfigurationManager.AppSettings["cdn"];
			return path + id + "/photo.png";
		}
		public Image Base64ToImage(string base64String)
		{
			// Convert Base64 String to byte[]
			byte[] imageBytes = Convert.FromBase64String(base64String);
			MemoryStream ms = new MemoryStream(imageBytes, 0,
			  imageBytes.Length);

			// Convert byte[] to Image
			ms.Write(imageBytes, 0, imageBytes.Length);
			Image image = Image.FromStream(ms, true);
			return image;
		}


		public  Image CropImage(Image originalImage,int x,int y,int wh)
		{
			Rectangle rect = new Rectangle(x, y, wh, wh);
			Bitmap bmpImage = new Bitmap(originalImage);
			return bmpImage.Clone(rect, bmpImage.PixelFormat);
		}

	}
}