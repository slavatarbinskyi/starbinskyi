using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using WebApi.ActionFilters;
using WebApp.ActionFilter;

namespace WebApp
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			// Configure Web API to use only bearer token authentication.
			config.SuppressDefaultHostAuthentication();
			config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

			// Web API routes
			config.MapHttpAttributeRoutes();
			config.Filters.Add(new LoggingFilterAttribute());
			config.Filters.Add(new GlobalExceptionAttribute());
			config.Routes.MapHttpRoute(
				"DefaultApi",
				"api/{controller}/{action}/{id}",
				new {id = RouteParameter.Optional}
			);
		}
	}
}