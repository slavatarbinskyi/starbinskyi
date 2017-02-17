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
using System.Drawing.Imaging;

namespace WebApp.Controllers
{
	public class HomeController : BaseController
	{
		private IUserManager userManager;
		private IToDoListManager toDoListManager;
		private IToDoItemManager toDoItemManager;
		private IInviteUserManager inviteUserManager;
		private IEmailService emailService;
		private ITagManager tagManager;
		private INotificationEmailService notificationService;
		public HomeController(IUserManager userManager, ITagManager tagManager, IToDoItemManager toDoItemManager, IToDoListManager toDoListManager, IInviteUserManager inviteUserManager, IEmailService emailService,INotificationEmailService notificationService)
		{
			this.emailService = emailService;
			this.inviteUserManager = inviteUserManager;
			this.userManager = userManager;
			this.toDoItemManager = toDoItemManager;
			this.toDoListManager = toDoListManager;
			this.tagManager = tagManager;
			this.notificationService = notificationService;
		}
		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}


		/// <summary>
		/// View for configuring user.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult ConfigureUser()
		{
			var userid = Convert.ToInt32(User.Identity.GetUserId());
			if (userid == 0)
			{
				return HttpNotFound();
			}
			var user = userManager.GetById(userid);

			return View(user);
		}
		/// <summary>
		/// Method for getting photo path.
		/// </summary>
		/// <returns></returns>
		public ActionResult Photo()
		{
			var id = User.Identity.GetUserId();
			if (id == null) { return null; }
			var imghelper = new ImageHelper();
			var path = imghelper.GetImagePath(id);
			return View(new UserModel() { UserImgUrl = path });
		}

		[HttpPost]
		public ActionResult ConfiguringUser(User user, string basestring, string points, HttpPostedFileBase Imagepost)
		{
			var imghelper = new ImageHelper();
			var path = ConfigurationManager.AppSettings["imageroot"];
			string[] pointsArray = points.Split(',');
			var wh = Convert.ToInt32(pointsArray[2]) - Convert.ToInt32(pointsArray[0]);
			var x = Convert.ToInt32(pointsArray[0]);
			var y = Convert.ToInt32(pointsArray[1]);
			var originalimage = Image.FromStream(Imagepost.InputStream, true, true);

			//the one of ways to save image via bitmap
			//imghelper.CropAndSavePoints(User.Identity.GetUserId(), path, originalimage, x, y, wh);

			imghelper.SaveImage(User.Identity.GetUserId(),basestring,path);

			userManager.UpdateUser(user);
			return RedirectToAction("Index", "Home");
		}

		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			return View();
		}
		/// <summary>
		/// Post for logout
		/// </summary>
		/// <returns></returns>
		public ActionResult Logout()
		{
			AuthenticationManager.SignOut(CookieAuthenticationDefaults.AuthenticationType);
			HttpContext.Response.Cookies.Set(new HttpCookie("token") { Value = string.Empty });
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public ActionResult RegisterInvitedUser(string guid)
		{
			User userDb = null;
			var invitedUser = inviteUserManager.GetByGuId(guid);
			if (invitedUser != null)
			{
				userDb = userManager.GetByEmail(invitedUser.Email);
				if (userDb == null)
				{
					userDb = new User()
					{
						Email = invitedUser.Email
					};
				}
			}
			return View(userDb);
		}
		/// <summary>
		/// Register new user.
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult RegisterUser(User user)
		{
			userManager.Insert(user);
			return RedirectToAction("Index", "Home");
		}
		[HttpPost]
		public JsonResult GetTopTags()
		{
			var tags = tagManager.GetTopTags();
			return Json(tags, JsonRequestBehavior.AllowGet);
		}
		/// <summary>
		/// Top tags.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult TopTags()
		{
			return View();
		}
		/// <summary>
		/// Invite user with email.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult InviteUser()
		{
			return View();
		}
		/// <summary>
		/// Send invite to email with emailservice.
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult SendInvite(string email)
		{
			var user = new InviteUser()
			{
				Email = email
			};
			var usersend = new User()
			{
				Email = user.Email
			};
			var guid = inviteUserManager.CreateInvite(user);
			var email_s = ConfigurationManager.AppSettings["Email"];
			var pass_s = ConfigurationManager.AppSettings["Password"];
			emailService.SendEmail(usersend, "localhost/ToDoWebApi/Home/RegisterInvitedUser/?guid=" + guid, email_s, pass_s);
			return RedirectToAction("Index", "Home");
		}


		[HttpGet]
		public ActionResult Login()
		{
			var model = new LoginModel();
			return View(model);
		}

		/// <summary>
		/// Method for login post;
		/// </summary>
		/// <param name="loguser"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Login(LoginModel loguser)
		{
			var userDb = userManager.Find(loguser.Name, loguser.Password);
			ApplicationUser user = new ApplicationUser()
			{
				Id = userDb.Id.ToString(),
				Email = userDb.Email,
				UserName = userDb.Email
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
