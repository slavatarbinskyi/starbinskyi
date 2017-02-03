using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			Bitmap bmp = new Bitmap(200, 200);
			using (Graphics graph = Graphics.FromImage(bmp))
			{
				Rectangle recblue = new Rectangle(0, 0, 200,100);
				graph.FillRectangle(Brushes.Blue, recblue);
				Rectangle recred = new Rectangle(0,100,200, 100);
				graph.FillRectangle(Brushes.Red, recred);

			}
			var img = (Image)bmp;
			var newimg = helper.CropImage(img, 0,100,100);
			if (newimg.Width != 100 || newimg.Height != 100)
			{
				Assert.Fail("Wrong size of image");
			}
			Bitmap bmpnew = new Bitmap(newimg);

			//Iterate whole bitmap to findout the picked color
			for (int i = 0; i < bmpnew.Height; i++)
			{
				for (int j = 0; j < bmpnew.Width; j++)
				{
					//Get the color at each pixel
					Color now_color = bmp.GetPixel(j, i);

					//Compare Pixel's Color ARGB property with the picked color's ARGB property 
					if (now_color.ToArgb() != Color.Blue.ToArgb())
					{
						Assert.Fail("Test failed");
					}
					else
					{
						Assert.Pass("Test done!");
					}
				}

			}
		}
	}
}
