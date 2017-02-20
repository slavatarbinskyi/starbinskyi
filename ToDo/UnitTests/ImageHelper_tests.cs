using System.Drawing;
using NUnit.Framework;
using WebApp.Helpers;

namespace UnitTests
{
	[TestFixture]
	public class ImageHelper_tests
	{
		[Test]
		public void CropImage()
		{
			var helper = new ImageHelper();
			var bmp = new Bitmap(200, 200);
			using (var graph = Graphics.FromImage(bmp))
			{
				var recblue = new Rectangle(0, 0, 200, 100);
				graph.FillRectangle(Brushes.Blue, recblue);
				var recred = new Rectangle(0, 100, 200, 100);
				graph.FillRectangle(Brushes.Red, recred);
			}
			var img = (Image) bmp;
			var newimg = helper.CropImage(img, 0, 100, 100);
			if (newimg.Width != 100 || newimg.Height != 100)
				Assert.Fail("Wrong size of image");
			var bmpnew = new Bitmap(newimg);

			//Iterate whole bitmap to findout the picked color
			for (var i = 0; i < bmpnew.Height; i++)
			for (var j = 0; j < bmpnew.Width; j++)
			{
				//Get the color at each pixel
				var now_color = bmp.GetPixel(j, i);

				//Compare Pixel's Color ARGB property with the picked color's ARGB property 
				if (now_color.ToArgb() != Color.Blue.ToArgb())
					Assert.Fail("Test failed");
				else
					Assert.Pass("Test done!");
			}
		}
	}
}