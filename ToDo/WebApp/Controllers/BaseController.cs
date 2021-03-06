﻿using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace webApiTask.Controllers
{
	public class BaseController : Controller
	{
		protected override JsonResult Json(object data, string contentType, Encoding contentEncoding,
			JsonRequestBehavior behavior)
		{
			return new JsonNetResult
			{
				Data = data,
				ContentType = contentType,
				ContentEncoding = contentEncoding,
				JsonRequestBehavior = behavior
			};
		}
	}

	public class JsonNetResult : JsonResult
	{
		public JsonNetResult()
		{
			Settings = new JsonSerializerSettings
			{
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			};
		}

		public JsonSerializerSettings Settings { get; }

		public override void ExecuteResult(ControllerContext context)
		{
			if (context == null)
				throw new ArgumentNullException("context");
			if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
			    string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
				throw new InvalidOperationException("JSON GET is not allowed");

			var response = context.HttpContext.Response;
			response.ContentType = string.IsNullOrEmpty(ContentType) ? "application/json" : ContentType;

			if (ContentEncoding != null)
				response.ContentEncoding = ContentEncoding;
			if (Data == null)
				return;

			var scriptSerializer = JsonSerializer.Create(Settings);

			using (var sw = new StringWriter())
			{
				scriptSerializer.Serialize(sw, Data);
				response.Write(sw.ToString());
			}
		}
	}
}