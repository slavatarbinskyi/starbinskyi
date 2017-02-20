using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using WebApp;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApp
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}

		private async Task<IEnumerable<Claim>> Authenticate(string username, string password)
		{
			// authenticate user
			if (username == password)
				return new List<Claim>
				{
					new Claim("name", username)
				};

			return null;
		}
	}
}