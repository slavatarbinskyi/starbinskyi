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
		public HomeController(IUserManager userManager, IToDoItemManager toDoItemManager, IToDoListManager toDoListManager,IInviteUserManager inviteUserManager, IEmailService emailService)
		{
			this.emailService = emailService;
			this.inviteUserManager = inviteUserManager;
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
			var result=toDoListManager.InsertList(list);
			return Json(result, JsonRequestBehavior.AllowGet);
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
			if (id == null) { return null; }
			var imghelper = new ImageHelper();
			var path=imghelper.GetImagePath(id);
			return View(new UserModel() { UserImgUrl = path });
		}

		[HttpPost]
		public ActionResult ConfiguringUser(User user,string basestring,string points,HttpPostedFileBase Imagepost)
		{
			var imghelper = new ImageHelper();
			var path = ConfigurationManager.AppSettings["imageroot"];
			string[] pointsArray = points.Split(',');
			var wh = Convert.ToInt32(pointsArray[2])-Convert.ToInt32(pointsArray[0]);
			var x = Convert.ToInt32(pointsArray[0]);
			var y = Convert.ToInt32(pointsArray[1]);
			var originalimage=Image.FromStream(Imagepost.InputStream, true, true);
			imghelper.CropAndSavePoints(User.Identity.GetUserId(), path,originalimage,x,y,wh);

			//imghelper.SaveImage(User.Identity.GetUserId(),basestring,path);

			userManager.UpdateUser(user);
			return RedirectToAction("Index", "Home");
		}
		[HttpGet]
		public JsonResult GetUsersList()
		{
			var userid = Convert.ToInt32(User.Identity.GetUserId());
			var lists = toDoListManager.GetAll().Where(i=>i.User_Id==userid).ToList();
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
		public ActionResult RegisterInvitedUser(string guid)
		{
			User userDb=null;
			var invitedUser = inviteUserManager.GetByGuId(guid);
			if (invitedUser != null)
			{
				userDb = userManager.GetByEmail(invitedUser.Email);
				if(userDb==null)
				{
					userDb = new User()
					{
						Email = invitedUser.Email
					};
				}
			}
			return View(userDb);
		}
		[HttpPost]
		public ActionResult RegisterUser(User user)
		{
			userManager.Insert(user);
			return RedirectToAction("Index", "Home");
		}


		[HttpGet]
		public ActionResult InviteUser()
		{
			return View();
		}
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
			var guid=inviteUserManager.CreateInvite(user);
			var email_s = ConfigurationManager.AppSettings["Email"];
			var pass_s = ConfigurationManager.AppSettings["Password"];
			emailService.SendEmail(usersend, "localhost/ToDoWebApi/Home/RegisterInvitedUser/?guid="+guid, email_s, pass_s);
			


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
