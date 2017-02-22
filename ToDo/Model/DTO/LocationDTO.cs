using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
	public class LocationDTO
	{
		public List<string> IdsList  { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }			
	}
}
