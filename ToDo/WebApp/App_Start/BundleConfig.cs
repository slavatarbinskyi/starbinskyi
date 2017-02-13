using System.Web;
using System.Web.Optimization;

namespace WebApp
{
	public class BundleConfig
	{
		// For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
				"~/Scripts/knockout-{version}.js",
				"~/Scripts/knockout.mapping-latest.debug.js"));

			bundles.Add(new ScriptBundle("~/bundles/homeko").Include(
				"~/Scripts/Homeko.js"));
			bundles.Add(new ScriptBundle("~/bundles/cookies").Include(
	"~/Scripts/jquery.cookie.js"));
			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
"~/Scripts/jquery-ui.min.js"));
			bundles.Add(new ScriptBundle("~/bundles/tageditor").Include(
			"~/Scripts/jquery.tag-editor.min.js",
			"~/Scripts/jquery.tag-editor.js",
			"~/Scripts/jquery.caret.min.js"));


			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/home").Include(
		  "~/Content/home.css"));

			bundles.Add(new StyleBundle("~/Content/uni").Include(
		  "~/Content/uni.css"));

			bundles.Add(new StyleBundle("~/Content/TagEditor").Include(
		"~/Content/jquery.tag-editor.css"));

		}
	}
}
