using BAL.Interface;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Model.DB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using webApiTask.Controllers;
using WebApp.Models;
using System.IO;
using System.Drawing;
using System.Configuration;
using WebApp.Helpers;

namespace WebApp.Controllers
{
	public class HomeController : BaseController
	{
		private IUserManager userManager;
		private IToDoListManager toDoListManager;
		private IToDoItemManager toDoItemManager;
		public HomeController(IUserManager userManager, IToDoItemManager toDoItemManager, IToDoListManager toDoListManager)
		{
			this.userManager = userManager;
			this.toDoItemManager = toDoItemManager;
			this.toDoListManager = toDoListManager;
		}
		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}
		
		[HttpPost]
		public JsonResult AddList(ToDoList list)
		{
			list.User_Id = Convert.ToInt32(User.Identity.GetUserId());
			toDoListManager.InsertList(list);
			return Json(list, JsonRequestBehavior.AllowGet);
		}
		[HttpPost]
		public JsonResult AddItem(ToDoItem item)
		{
			var model=toDoItemManager.InsertItem(item);
			return Json(model,JsonRequestBehavior.AllowGet);

		}
		[HttpPost]
		public void RemoveList(int id)
		{
			toDoListManager.RemoveList(id);
		}
		[HttpPost]
		public void RemoveItem(int? id)
		{
			toDoItemManager.RemoveItem(id);
		}
		[HttpPost]
		public void MarkItem(int id, bool newvalue)
		{
			toDoItemManager.ChangeIsCompletedValue(id, newvalue);
		}
		[HttpPost]
		public void SetName(int id, string newName)
		{
			toDoListManager.SetName(id, newName);
		}
		[HttpPost]
		public void SetText(int id, string newText)
		{
			toDoItemManager.SetText(id, newText);
		}

		[HttpGet]
		public ActionResult ConfigureUser()
		{
			var userid = Convert.ToInt32(User.Identity.GetUserId());
			if(userid==0)
			{
				return HttpNotFound();
			}
			var user = userManager.GetById(userid);

			return View(user);
		}

		public ActionResult Photo()
		{
			var id=User.Identity.GetUserId();
			var imghelper = new ImageHelper();
			var path=imghelper.GetImagePath(id);
			return File(path, "image/jpeg");
		}

		[HttpPost]
		public ActionResult ConfiguringUser(User user, HttpPostedFileBase image)
		{
			var path = ConfigurationManager.AppSettings["imageroot"];
			var imghelper = new ImageHelper();
			imghelper.SaveImage(User.Identity.GetUserId(), image, path);
			userManager.UpdateUser(user);
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public JsonResult GetUsersList()
		{
			var userid = Convert.ToInt32(User.Identity.GetUserId());
			var lists = toDoListManager.GetAll().Where(i => i.User_Id == userid);
			return Json(lists, JsonRequestBehavior.AllowGet);
		}

		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";

			return View();
		}
		// POST api/Home/Logout

		public ActionResult Logout()
		{
			AuthenticationManager.SignOut(CookieAuthenticationDefaults.AuthenticationType);
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public ActionResult Login()
		{
			var model = new LoginModel();
			return View(model);
		}

		// POST api/Home/Login
		[HttpPost]
		public ActionResult Login(LoginModel loguser)
		{
			var userDb = userManager.Find(loguser.Name, loguser.Password);
			ApplicationUser user = new ApplicationUser()
			{
				Id = userDb.Id.ToString(),
				Email = userDb.Email,
				UserName = userDb.UserName
			};

			ClaimsIdentity cookiesIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			cookiesIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
			cookiesIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
			cookiesIdentity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/201..",
			"OWIN Provider", ClaimValueTypes.String));
			AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, cookiesIdentity);
			return RedirectToAction("Index", "Home");
		}
	}
}
