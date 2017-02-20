﻿using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace WebApp.Controllers
{
	/// <summary>
	///     Controller for claims.
	/// </summary>
	[RoutePrefix("api/claims")]
	public class ClaimsController : ApiController
	{
		[Authorize]
		[Route("")]
		public IHttpActionResult GetClaims()
		{
			var identity = User.Identity as ClaimsIdentity;

			var claims = from c in identity.Claims
				select new
				{
					subject = c.Subject.Name,
					type = c.Type,
					value = c.Value
				};

			return Ok(claims);
		}
	}
}