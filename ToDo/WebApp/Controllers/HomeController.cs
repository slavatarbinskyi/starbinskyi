using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BAL.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Model.DB;
using Model.DTO;
using webApiTask.Controllers;
using WebApp.Helpers;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class HomeController : BaseController
	{
		private readonly IEmailService emailService;
		private readonly IInviteUserManager inviteUserManager;
		private INotificationEmailService notificationService;
		private readonly ITagManager tagManager;
		private IToDoItemManager toDoItemManager;
		private IToDoListManager toDoListManager;
		private readonly IUserManager userManager;

		public HomeController(IUserManager userManager, ITagManager tagManager, IToDoItemManager toDoItemManager,
			IToDoListManager toDoListManager, IInviteUserManager inviteUserManager, IEmailService emailService,
			INotificationEmailService notificationService)
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
			get { return HttpContext.GetOwinContext().Authentication; }
		}


		/// <summary>
		///     View for configuring user.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult ConfigureUser()
		{
			var userid = Convert.ToInt32(User.Identity.GetUserId());
			if (userid == 0)
				return HttpNotFound();
			var user = userManager.GetById(userid);

			return View(user);
		}

		/// <summary>
		///     Method for getting photo path.
		/// </summary>
		/// <returns></returns>
		public ActionResult Photo()
		{
			var id = User.Identity.GetUserId();
			if (id == null) return null;
			var imghelper = new ImageHelper();
			var path = imghelper.GetImagePath(id);
			return View(new UserModel {UserImgUrl = path});
		}

		[HttpPost]
		public ActionResult ConfiguringUser(User user, string basestring, string points, HttpPostedFileBase Imagepost)
		{
			var imghelper = new ImageHelper();
			var path = ConfigurationManager.AppSettings["imageroot"];
			var pointsArray = points.Split(',');
			var wh = Convert.ToInt32(pointsArray[2]) - Convert.ToInt32(pointsArray[0]);
			var x = Convert.ToInt32(pointsArray[0]);
			var y = Convert.ToInt32(pointsArray[1]);
			var originalimage = Image.FromStream(Imagepost.InputStream, true, true);

			//the one of ways to save image via bitmap
			//imghelper.CropAndSavePoints(User.Identity.GetUserId(), path, originalimage, x, y, wh);

			imghelper.SaveImage(User.Identity.GetUserId(), basestring, path);

			userManager.UpdateUser(user);
			return RedirectToAction("Index", "Home");
		}

		public ActionResult Index()
		{
			ViewBag.Title = "Home Page";
			return View();
		}

		/// <summary>
		///     Post for logout
		/// </summary>
		/// <returns></returns>
		public ActionResult Logout()
		{
			AuthenticationManager.SignOut(CookieAuthenticationDefaults.AuthenticationType);
			HttpContext.Response.Cookies.Set(new HttpCookie("token") {Value = string.Empty});
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// View for registering invited users
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		[HttpGet]
		public ActionResult RegisterInvitedUser(string guid)
		{
			User userDb = null;
			var invitedUser = inviteUserManager.GetByGuId(guid);
			if (invitedUser != null)
			{
				userDb = userManager.GetByEmail(invitedUser.Email);
				if (userDb == null)
					userDb = new User
					{
						Email = invitedUser.Email
					};
			}
			return View(userDb);
		}

		/// <summary>
		///     Register new user.
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult RegisterUser(User user)
		{
			userManager.Insert(user);
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// Get top tags
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public JsonResult GetTopTags()
		{
			var tags = tagManager.GetTopTags();
			return Json(tags, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		///     Top tags.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult TopTags()
		{
			return View();
		}

		/// <summary>
		///     Invite user with email.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult InviteUser()
		{
			return View();
		}

		/// <summary>
		///     Send invite to email with emailservice.
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult SendInvite(string email)
		{
			var user = new InviteUser
			{
				Email = email
			};
			var usersend = new User
			{
				Email = user.Email
			};
			var guid = inviteUserManager.CreateInvite(user);
			var email_s = ConfigurationManager.AppSettings["Email"];
			var pass_s = ConfigurationManager.AppSettings["Password"];
			emailService.SendEmail(usersend, "localhost/ToDoWebApi/Home/RegisterInvitedUser/?guid=" + guid, email_s, pass_s);
			return RedirectToAction("Index", "Home");
		}

		/// <summary>
		/// View for login page
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult Login()
		{
			var model = new LoginModel();
			return View(model);
		}

		/// <summary>
		/// View for attaching location to note.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult Location()
		{

			return View();
		}


		/// <summary>
		/// View for users chat;
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult UserChat()
		{
			return View();
		}



		/// <summary>
		/// Export to xml todo.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult ExportToExcel()
		{
			var converter = new ListToDataTableConverter();
			var lists = toDoListManager.GetAll();
			var wb=converter.ExportToExcel(lists);

			Response.Clear();
			Response.Buffer = true;
			Response.ContentEncoding = Encoding.UTF8;
			Response.Charset = "";
			Response.AddHeader("Content-Disposition",
			  "attachment; filename=MyToDo.xls");
			Response.ContentType =
			  "application/vnd.ms-excel";

			using (MemoryStream memoryStream = new MemoryStream())
			{
				wb.SaveAs(memoryStream);
				memoryStream.WriteTo(Response.OutputStream);
				memoryStream.Close();
			}

			Response.End();

			return RedirectToAction("Index", "Home");
		}


		/// <summary>
		///     Method for login post;
		/// </summary>
		/// <param name="loguser"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Login(LoginModel loguser)
		{
			var userDb = userManager.Find(loguser.Name, loguser.Password);
			var user = new ApplicationUser
			{
				Id = userDb.Id.ToString(),
				Email = userDb.Email,
				UserName = userDb.Email
			};

			var cookiesIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationType,
				ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
			cookiesIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id, ClaimValueTypes.String));
			cookiesIdentity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email, ClaimValueTypes.String));
			cookiesIdentity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/201..",
				"OWIN Provider", ClaimValueTypes.String));
			AuthenticationManager.SignIn(new AuthenticationProperties {IsPersistent = true}, cookiesIdentity);
			return RedirectToAction("Index", "Home");
		}
	}
}