using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
	public class LocationDTO
	{
		public List<int> IdsList  { get; set; }
		public List<string> ListsName { get; set; }
		public double Lat { get; set; }
		public double Lon { get; set; }			
	}
}
