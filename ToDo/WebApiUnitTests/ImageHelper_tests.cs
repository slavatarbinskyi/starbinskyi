using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Helpers;

namespace WebApiUnitTests
{
	[TestFixture]
	public class ImageHelper_tests
	{
		[Test]
		public void CropImage()
		{
			var helper = new ImageHelper();
			Bitmap bmp = new Bitmap(200,200);
			using (Graphics graph = Graphics.FromImage(bmp))
			{
				Rectangle ImageSize = new Rectangle(0, 0,100,100);
				graph.FillRectangle(Brushes.Red, ImageSize);
				
			}
		}
	}
}
