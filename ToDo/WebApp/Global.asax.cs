using BAL.Interface;
using BAL.Manager;
using DAL;
using DAL.Interface;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Helpers;

namespace WebApp
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			InjectorContainer();
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}
		private void InjectorContainer()
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
			container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
			container.Register<IUserManager, UserManager>();
			container.Register<IToDoItemManager, ToDoItemManager>();
			container.Register<IToDoListManager, ToDoListManager>();
			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

		}
	}
}
